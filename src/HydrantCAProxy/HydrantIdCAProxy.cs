using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using CAProxy.AnyGateway;
using CAProxy.AnyGateway.Interfaces;
using CAProxy.AnyGateway.Models;
using CAProxy.Common;
using CSS.PKI;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Interfaces;
using Keyfactor.HydrantId;
using Keyfactor.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CSS.Common.Logging;
using System.Threading.Tasks;
using LogHandler = Keyfactor.Logging.LogHandler;
using CSS.Common;
using Keyfactor.HydrantId.Client.Models;
using System.Diagnostics;

namespace Keyfactor.AnyGateway.Google
{
    public class HydrantIdCAProxy : BaseCAConnector
    {
        private static readonly ILogger Log = LogHandler.GetClassLogger<HydrantIdCAProxy>();
        private RequestManager _requestManager;
        private ICAConnectorConfigProvider Config { get; set; }

        public override EnrollmentResult Enroll(ICertificateDataReader certificateDataReader, string csr,
            string subject, Dictionary<string, string[]> san, EnrollmentProductInfo productInfo,
            PKIConstants.X509.RequestFormat requestFormat, RequestUtilities.EnrollmentType enrollmentType)
        {
            Log.MethodEntry();
            _requestManager=new RequestManager();
            CertRequestResult enrollmentResponse = null;
            int timerTries = 0;
            Certificate csrTrackingResponse = null;
            var client = new HydrantIdClient(Config);

            switch (enrollmentType)
            {
                case RequestUtilities.EnrollmentType.New:
                case RequestUtilities.EnrollmentType.Reissue:
                    Log.LogTrace("Entering New Enrollment");

                    var policyListResult =
                        Task.Run(async () => await client.GetPolicyList())
                            .Result;

                    Log.LogTrace($"Policy Result List: {JsonConvert.SerializeObject(policyListResult)}");
                    var policyId = policyListResult.Single(p => p.Name.Equals(productInfo.ProductID));

                    Log.LogTrace($"PolicyId: {JsonConvert.SerializeObject(policyId)}");

                    var enrollmentRequest =
                        _requestManager.GetEnrollmentRequest(policyId.Id, productInfo, csr, san);

                    Log.LogTrace($"Enrollment Request JSON: {JsonConvert.SerializeObject(enrollmentRequest)}");
                    enrollmentResponse =
                        Task.Run(async () => await client.GetSubmitEnrollmentAsync(enrollmentRequest))
                            .Result;
                    Log.LogTrace($"Enrollment Response JSON: {JsonConvert.SerializeObject(enrollmentResponse)}");

                    if (enrollmentResponse?.ErrorReturn?.Status != "Failure")
                    {
                        timerTries = +1;
                        csrTrackingResponse = GetCertificateOnTimer(enrollmentResponse?.RequestStatus?.Id);
                    }
                    else
                    {
                        return new EnrollmentResult
                        {
                            Status = 30, //failure
                            StatusMessage = $"Enrollment Failed with error {enrollmentResponse?.ErrorReturn?.Error}"
                        };
                    }


                    Log.MethodExit();

                    break;

                case RequestUtilities.EnrollmentType.Renew:
                    Log.LogTrace("Entering Renew...");

                    var renewalRequest = _requestManager.GetRenewalRequest(csr, false);
                    Log.LogTrace($"Renewal Request JSON: {JsonConvert.SerializeObject(renewalRequest)}");
                    var sn = productInfo.ProductParameters["PriorCertSN"];
                    Log.LogTrace($"Prior Cert Serial Number= {sn}");
                    var priorCert = certificateDataReader.GetCertificateRecord(
                        DataConversion.HexToBytes(sn));

                    var uUId = priorCert.CARequestID; //uUId is a GUID

                    Log.LogTrace($"Hydrant Certificate Id Plus Serial #= {uUId}");

                    Log.LogTrace($"Reissue CA RequestId: {uUId}");
                    var certificateId = uUId.Substring(0, 36);
                    enrollmentResponse =
                        Task.Run(async () =>
                                await client.GetSubmitRenewalAsync(certificateId, renewalRequest))
                            .Result;
                    Log.LogTrace($"Renew Response JSON: {JsonConvert.SerializeObject(enrollmentResponse)}");

                    if (enrollmentResponse?.ErrorReturn?.Status != "Failure")
                    {
                        timerTries = +1;
                        csrTrackingResponse = GetCertificateOnTimer(enrollmentResponse?.RequestStatus?.Id);
                    }
                    else
                    {
                        return new EnrollmentResult
                        {
                            Status = 30, //failure
                            StatusMessage = $"Enrollment Failed with error {enrollmentResponse?.ErrorReturn?.Error}"
                        };
                    }
                    break;
            }

            if (csrTrackingResponse == null && timerTries > 0)
            {
                return new EnrollmentResult
                {
                    Status = 30, //failure
                    StatusMessage = $"Certificate may still waiting on Hydrant and is not ready for download"
                };
            }

            var cert = GetSingleRecord(csrTrackingResponse.Id.ToString());
            return _requestManager.GetEnrollmentResult(csrTrackingResponse, cert);
        }

        public override CAConnectorCertificate GetSingleRecord(string caRequestId)
        {
            Logger.MethodEntry();
            _requestManager = new RequestManager();
            Log.LogTrace($"Keyfactor Ca Id: {caRequestId}");
            try
            {
                var client = new HydrantIdClient(Config);
                var certificateResponse =
                    Task.Run(async () =>
                            await client.GetSubmitGetCertificateAsync(caRequestId.Substring(0, 36)))
                        .Result;

                Log.LogTrace($"Single Cert JSON: {JsonConvert.SerializeObject(certificateResponse)}");
                Log.MethodExit();
                return new CAConnectorCertificate
                {
                    CARequestID = caRequestId,
                    Certificate = certificateResponse.Pem,
                    ResolutionDate = Convert.ToDateTime(certificateResponse.NotAfter),
                    Status = _requestManager.GetMapReturnStatus(certificateResponse.RevocationStatus),
                    SubmissionDate = Convert.ToDateTime(certificateResponse.CreatedAt)
                };
            }
            catch (Exception) //Most likely cert is not available yet, just get it on the sync
            {
                return new CAConnectorCertificate
                {
                    CARequestID = caRequestId,
                    Status = _requestManager.GetMapReturnStatus(0) //Unknown
                };
            }
        }

        public override void Initialize(ICAConnectorConfigProvider configProvider)
        {
            Log.MethodEntry();
            try
            {
                Config = configProvider;
            }
            catch (Exception ex)
            {
                Log.LogError($"Failed to initialize GCP CAS CAPlugin: {ex}");
            }
        }

        public override void Ping()
        {
            Log.MethodEntry();
            Log.MethodExit();
        }

        public override int Revoke(string caRequestId, string hexSerialNumber, uint revocationReason)
        {
            try
            {
                Logger.LogTrace("Staring Revoke Method");
                _requestManager = new RequestManager();
                var client = new HydrantIdClient(Config);
                var hydrantId = caRequestId.Substring(0, 36);
                var revokeReason = _requestManager.GetMapRevokeReasons(revocationReason);

                Logger.LogTrace($"Revoke Reason {revokeReason}");

                var revokeResponse = Task.Run(async () =>
                        await client.GetSubmitRevokeCertificateAsync(hydrantId, revokeReason))
                    .Result;

                Logger.LogTrace($"Revoke Response JSON: {JsonConvert.SerializeObject(revokeResponse)}");
                Logger.MethodExit();
                return 1;
            }
            catch (Exception e)
            {
                Logger.LogError($"An Error has occurred during the revoke process {e.Message}");
                Logger.MethodExit();
                return -1;
            }
        }

        private Certificate GetCertificateOnTimer(string Id)
        {
            //Get the csr tracking response from the tracking Id returned from Enrollment
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var client = new HydrantIdClient(Config);
            Certificate csrTrackingResponse = null;

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(30) && csrTrackingResponse == null)
            {
                try
                {
                    csrTrackingResponse =
                    Task.Run(async () => await client.GetSubmitGetCertificateByCsrAsync(Id))
                        .Result;
                }
                catch (System.AggregateException e)
                {
                    Log.LogTrace($"Enrollment Response Not Available Yet, try again {LogHandler.FlattenException(e)}.");
                }
                Thread.Sleep(1000);
            }

            return csrTrackingResponse;
        }

        public override void Synchronize(ICertificateDataReader certificateDataReader,
            BlockingCollection<CAConnectorCertificate> blockingBuffer,
            CertificateAuthoritySyncInfo certificateAuthoritySyncInfo,
            CancellationToken cancelToken)
        {
            Log.MethodEntry();
            _requestManager = new RequestManager();
            try
            {
                var certs = new BlockingCollection<ICertificatesResponseItem>(100);
                var client = new HydrantIdClient(Config);
                _ = client.GetSubmitCertificateListRequestAsync(certs, cancelToken);

                foreach (var currentResponseItem in certs.GetConsumingEnumerable(cancelToken))
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        Log.LogError("Synchronize was canceled.");
                        break;
                    }

                    try
                    {
                        Log.LogTrace($"Took Certificate ID {currentResponseItem?.Id} from Queue");
                        if (currentResponseItem != null)
                        {
                            var certStatus = _requestManager.GetMapReturnStatus(currentResponseItem.RevocationStatus);
                            Log.LogTrace($"Numeric Status {certStatus}");

                            if (certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.ISSUED) ||
                                certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.REVOKED))
                            {
                                var productId = currentResponseItem.Policy.Name;
                                Log.LogTrace($"Product Id {productId}");

                                var singleCert = client.GetSubmitGetCertificateAsync(currentResponseItem.Id);

                                var fileContent = singleCert.Result.Pem ?? string.Empty;

                                Log.LogTrace($"Certificate Content: {fileContent}");

                                if (fileContent.Length > 0)
                                {
                                    var certData = fileContent.Replace("\n", string.Empty);
                                    var splitCerts =
                                        certData.Split(
                                            new[] { "-----END CERTIFICATE-----", "-----BEGIN CERTIFICATE-----" },
                                            StringSplitOptions.RemoveEmptyEntries);
                                    foreach (var cert in splitCerts)
                                        try
                                        {
                                            var currentCert = new X509Certificate2(Encoding.ASCII.GetBytes(cert));
                                            var caReqId = $"{currentResponseItem.Id}-{currentCert.SerialNumber}";
                                            Log.LogTrace($"Split Cert Value: {cert}");
                                            blockingBuffer.Add(new CAConnectorCertificate
                                            {
                                                CARequestID = $"{currentResponseItem.Id}",
                                                Certificate = cert,
                                                SubmissionDate = Convert.ToDateTime(singleCert.Result.CreatedAt),
                                                Status = certStatus,
                                                ProductID = productId
                                            }, cancelToken);
                                        }
                                        catch (Exception e)
                                        {
                                            Log.LogError(
                                                $"Exception occurred Adding Cert to buffer: {e.Message} HydrantId: {currentResponseItem.Id} CommonName: {currentResponseItem.CommonName} Serial: {currentResponseItem.Serial}");
                                        }
                                }
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        Log.LogError("Synchronize was canceled.");
                        break;
                    }
                }
            }
            catch (AggregateException aggEx)
            {
                Log.LogError("Csc Global Synchronize Task failed!");
                Log.MethodExit();
                // ReSharper disable once PossibleIntendedRethrow
                throw aggEx;
            }

            Log.MethodExit();
        }


        public override void ValidateCAConnectionInfo(Dictionary<string, object> connectionInfo)
        {
            Log.MethodEntry();
            List<string> errors = new List<string>();

            Log.LogTrace("Checking required CAConnection config");
            errors.AddRange(CheckRequiredValues(connectionInfo));

            if (errors.Any()) throw new Exception(string.Join("|", errors.ToArray()));
        }

        public override void ValidateProductInfo(EnrollmentProductInfo productInfo,
            Dictionary<string, object> connectionInfo)
        {
            Log.MethodEntry();
            //TODO: Evaluate Template (if avaiable) based on ProductInfo
            Log.MethodExit();
        }

        private static List<string> CheckRequiredValues(Dictionary<string, object> connectionInfo, params string[] args)
        {
            List<string> errors = new List<string>();
            foreach (string s in args)
                if (string.IsNullOrEmpty(connectionInfo[s] as string))
                    errors.Add($"{s} is a required value");
            return errors;
        }


        private static readonly Func<string, string> pemify = ss =>
            ss.Length <= 64 ? ss : ss.Substring(0, 64) + "\n" + pemify(ss.Substring(64));



        #region Obsolete Methods

        [Obsolete]
        public override EnrollmentResult Enroll(string csr, string subject, Dictionary<string, string[]> san,
            EnrollmentProductInfo productInfo, PKIConstants.X509.RequestFormat requestFormat,
            RequestUtilities.EnrollmentType enrollmentType)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public override void Synchronize(ICertificateDataReader certificateDataReader,
            BlockingCollection<CertificateRecord> blockingBuffer,
            CertificateAuthoritySyncInfo certificateAuthoritySyncInfo,
            CancellationToken cancelToken,
            string logicalName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}