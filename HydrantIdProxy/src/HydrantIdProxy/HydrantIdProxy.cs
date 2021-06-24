using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAProxy.AnyGateway;
using CAProxy.AnyGateway.Interfaces;
using CAProxy.AnyGateway.Models;
using CAProxy.Common;
using CSS.Common.Logging;
using CSS.PKI;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId
{
    public class HydrantIdProxy : BaseCAConnector
    {
        public HydrantIdClient HydrantIdClient { get; set; }
        public bool EnableTemplateSync { get; set; }
        private readonly RequestManager _requestManager;

        public HydrantIdProxy()
        {
            _requestManager = new RequestManager();
        }

        public override int Revoke(string caRequestId, string hexSerialNumber, uint revocationReason)
        {
            try
            {
                Logger.Trace("Staring Revoke Method");

                var revokeResponse = Task.Run(async () => await HydrantIdClient.GetSubmitRevokeCertificateAsync(caRequestId))
                        .Result;

                Logger.Trace($"Revoke Response JSON: {JsonConvert.SerializeObject(revokeResponse)}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                return 1;
            }
            catch (Exception e)
            {
                Logger.Error($"An Error has occurred during the revoke process {e.Message}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                return Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.FAILED);
            }
        }

        [Obsolete]
        public override void Synchronize(ICertificateDataReader certificateDataReader,
            BlockingCollection<CertificateRecord> blockingBuffer,
            CertificateAuthoritySyncInfo certificateAuthoritySyncInfo, CancellationToken cancelToken,
            string logicalName)
        {
        }

        public override void Synchronize(ICertificateDataReader certificateDataReader,
            BlockingCollection<CAConnectorCertificate> blockingBuffer,
            CertificateAuthoritySyncInfo certificateAuthoritySyncInfo,
            CancellationToken cancelToken)
        {
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
            try
            {

                var certs = new BlockingCollection<ICertificatesResponseItem>(100);
                _ = HydrantIdClient.GetSubmitCertificateListRequestAsync(certs, cancelToken);

                foreach (var currentResponseItem in certs.GetConsumingEnumerable(cancelToken))
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        Logger.Error("Synchronize was canceled.");
                        break;
                    }

                    try
                    {
                        Logger.Trace($"Took Certificate ID {currentResponseItem?.Id} from Queue");
                        if (currentResponseItem != null)
                        {
                            var certStatus = _requestManager.GetMapReturnStatus(currentResponseItem.RevocationStatus);

                            if (certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.ISSUED) ||
                                certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.REVOKED))
                            {
                                var productId =  currentResponseItem.Policy.Name;

                                var singleCert = HydrantIdClient.GetSubmitGetCertificateAsync(currentResponseItem.Id);
                                
                                var fileContent =singleCert.Result.Pem ?? string.Empty;

                                Logger.Trace($"Certificate Content: {fileContent}");

                                if (fileContent.Length > 0)
                                {
                                    var certData = fileContent.Replace("\n", string.Empty);
                                    var splitCerts =
                                        certData.Split(new[] {"-----END CERTIFICATE-----", "-----BEGIN CERTIFICATE-----"},
                                            StringSplitOptions.RemoveEmptyEntries);
                                    foreach (var cert in splitCerts)
                                        try
                                        {
                                            var currentCert = new X509Certificate2(Encoding.ASCII.GetBytes(cert));
                                            Logger.Trace($"Split Cert Value: {cert}");
                                            blockingBuffer.Add(new CAConnectorCertificate
                                                {
                                                    CARequestID =
                                                        $"{currentResponseItem.Id}-{currentCert.SerialNumber}",
                                                    Certificate = cert,
                                                    SubmissionDate = Convert.ToDateTime(singleCert.Result.CreatedAt),
                                                    Status = certStatus,
                                                    ProductID = productId
                                                }, cancelToken);
                                        }
                                        catch (Exception e)
                                        {
                                            Logger.Trace($"Exception occurred Adding Cert to buffer: {e.Message}");
                                        }
                                }
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        Logger.Error("Synchronize was canceled.");
                        break;
                    }
                }
            }
            catch (AggregateException aggEx)
            {
                Logger.Error("Csc Global Synchronize Task failed!");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                // ReSharper disable once PossibleIntendedRethrow
                throw aggEx;
            }

            Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
        }

        [Obsolete]
        public override EnrollmentResult Enroll(string csr, string subject, Dictionary<string, string[]> san,
            EnrollmentProductInfo productInfo,
            PKIConstants.X509.RequestFormat requestFormat, RequestUtilities.EnrollmentType enrollmentType)
        {
            return null;
        }

        public override EnrollmentResult Enroll(ICertificateDataReader certificateDataReader, string csr,
            string subject, Dictionary<string, string[]> san, EnrollmentProductInfo productInfo,
            PKIConstants.X509.RequestFormat requestFormat, RequestUtilities.EnrollmentType enrollmentType)
        {

            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);

            switch (enrollmentType)
            {
                case RequestUtilities.EnrollmentType.New:
                    Logger.Trace($"Entering New Enrollment");
                    //If they renewed an expired cert it gets here and this will not be supported

                    var enrollmentRequest = _requestManager.GetEnrollmentRequest(productInfo, csr, san);
                    Logger.Trace($"Enrollment Request JSON: {JsonConvert.SerializeObject(enrollmentRequest)}");
                    var enrollmentResponse =
                        Task.Run(async () => await HydrantIdClient.GetSubmitEnrollmentAsync(enrollmentRequest))
                            .Result;
                    Logger.Trace($"Enrollment Response JSON: {JsonConvert.SerializeObject(enrollmentResponse)}");

                    Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                    return _requestManager.GetEnrollmentResult(enrollmentResponse);
            }

            return null;
        }


        public override CAConnectorCertificate GetSingleRecord(string caRequestId)
        {
             Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
             var keyfactorCaId = caRequestId.Substring(38); //todo fix to use pipe delimiter
             Logger.Trace($"Keyfactor Ca Id: {keyfactorCaId}");
             var certificateResponse =
                 Task.Run(async () => await HydrantIdClient.GetSubmitGetCertificateAsync(caRequestId))
                     .Result;

             Logger.Trace($"Single Cert JSON: {JsonConvert.SerializeObject(certificateResponse)}");
             Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
             return new CAConnectorCertificate
             {
                 CARequestID = keyfactorCaId,
                 Certificate = certificateResponse.Pem,
                 ResolutionDate = Convert.ToDateTime(certificateResponse.NotAfter),
                 Status = _requestManager.GetMapReturnStatus(certificateResponse.RevocationStatus),
                 SubmissionDate = Convert.ToDateTime(certificateResponse.CreatedAt)
             };
        }

        public override void Initialize(ICAConnectorConfigProvider configProvider)
        {
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
            HydrantIdClient = new HydrantIdClient(configProvider);
            Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
        }

        public override void Ping()
        {
        }

        public override void ValidateCAConnectionInfo(Dictionary<string, object> connectionInfo)
        {
        }

        public override void ValidateProductInfo(EnrollmentProductInfo productInfo,
            Dictionary<string, object> connectionInfo)
        {
        }

    }
}