// Copyright 2023 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAProxy.AnyGateway;
using CAProxy.AnyGateway.Interfaces;
using CAProxy.AnyGateway.Models;
using CAProxy.Common;
using CSS.Common;
using CSS.Common.Logging;
using CSS.PKI;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId
{
    public class HydrantIdProxy : BaseCAConnector
    {
        private readonly RequestManager _requestManager;

        public HydrantIdProxy()
        {
            _requestManager = new RequestManager();
        }

        public HydrantIdClient HydrantIdClient { get; set; }
        public bool EnableTemplateSync { get; set; }

        public override int Revoke(string caRequestId, string hexSerialNumber, uint revocationReason)
        {
            try
            {
                Logger.Trace("Staring Revoke Method");

                var hydrantId = caRequestId.Substring(0, 36);
                var revokeReason = _requestManager.GetMapRevokeReasons(revocationReason);

                Logger.Trace($"Revoke Reason {revokeReason}");

                var revokeResponse = Task.Run(async () =>
                        await HydrantIdClient.GetSubmitRevokeCertificateAsync(hydrantId, revokeReason))
                    .Result;

                Logger.Trace($"Revoke Response JSON: {JsonConvert.SerializeObject(revokeResponse)}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                return 1;
            }
            catch (Exception e)
            {
                Logger.Error($"An Error has occurred during the revoke process {e.Message}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                return -1;
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
                            Logger.Trace($"Numeric Status {certStatus}");

                            if (certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.ISSUED) ||
                                certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.REVOKED))
                            {
                                var productId = currentResponseItem.Policy.Name;
                                Logger.Trace($"Product Id {productId}");

                                var singleCert = HydrantIdClient.GetSubmitGetCertificateAsync(currentResponseItem.Id);

                                var fileContent = singleCert.Result.Pem ?? string.Empty;

                                Logger.Trace($"Certificate Content: {fileContent}");

                                if (fileContent.Length > 0)
                                {
                                    var certData = fileContent.Replace("\n", string.Empty);
                                    var splitCerts =
                                        certData.Split(
                                            new[] {"-----END CERTIFICATE-----", "-----BEGIN CERTIFICATE-----"},
                                            StringSplitOptions.RemoveEmptyEntries);
                                    foreach (var cert in splitCerts)
                                        try
                                        {
                                            var currentCert = new X509Certificate2(Encoding.ASCII.GetBytes(cert));
                                            var caReqId = $"{currentResponseItem.Id}-{currentCert.SerialNumber}";
                                            Logger.Trace($"Split Cert Value: {cert}");
                                            blockingBuffer.Add(new CAConnectorCertificate
                                            {
                                                CARequestID =$"{currentResponseItem.Id}",
                                                Certificate = cert,
                                                SubmissionDate = Convert.ToDateTime(singleCert.Result.CreatedAt),
                                                Status = certStatus,
                                                ProductID = productId
                                            }, cancelToken);
                                        }
                                        catch (Exception e)
                                        {
                                            Logger.Error(
                                                $"Exception occurred Adding Cert to buffer: {e.Message} HydrantId: {currentResponseItem.Id} CommonName: {currentResponseItem.CommonName} Serial: {currentResponseItem.Serial}");
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
            CertRequestResult enrollmentResponse = null;
            int timerTries = 0;
            Certificate csrTrackingResponse=null;

            switch (enrollmentType)
            {
                case RequestUtilities.EnrollmentType.New:
                case RequestUtilities.EnrollmentType.Reissue:
                    Logger.Trace("Entering New Enrollment");

                    var policyListResult =
                        Task.Run(async () => await HydrantIdClient.GetPolicyList())
                            .Result;

                    Logger.Trace($"Policy Result List: {JsonConvert.SerializeObject(policyListResult)}");
                    var policyId = policyListResult.Single(p => p.Name.Equals(productInfo.ProductID));

                    Logger.Trace($"PolicyId: {JsonConvert.SerializeObject(policyId)}");

                    var enrollmentRequest =
                        _requestManager.GetEnrollmentRequest(policyId.Id, productInfo, csr, san);

                    Logger.Trace($"Enrollment Request JSON: {JsonConvert.SerializeObject(enrollmentRequest)}");
                    enrollmentResponse =
                        Task.Run(async () => await HydrantIdClient.GetSubmitEnrollmentAsync(enrollmentRequest))
                            .Result;
                    Logger.Trace($"Enrollment Response JSON: {JsonConvert.SerializeObject(enrollmentResponse)}");

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


                    Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);

                    break;

                case RequestUtilities.EnrollmentType.Renew:
                    Logger.Trace("Entering Renew...");

                    var renewalRequest = _requestManager.GetRenewalRequest(csr, false);
                    Logger.Trace($"Renewal Request JSON: {JsonConvert.SerializeObject(renewalRequest)}");
                    var sn = productInfo.ProductParameters["PriorCertSN"];
                    Logger.Trace($"Prior Cert Serial Number= {sn}");
                    var priorCert = certificateDataReader.GetCertificateRecord(
                        DataConversion.HexToBytes(sn));

                    var uUId = priorCert.CARequestID; //uUId is a GUID

                    Logger.Trace($"Hydrant Certificate Id Plus Serial #= {uUId}");

                    Logger.Trace($"Reissue CA RequestId: {uUId}");
                    var certificateId = uUId.Substring(0, 36);
                    enrollmentResponse =
                        Task.Run(async () =>
                                await HydrantIdClient.GetSubmitRenewalAsync(certificateId, renewalRequest))
                            .Result;
                    Logger.Trace($"Renew Response JSON: {JsonConvert.SerializeObject(enrollmentResponse)}");

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

            if(csrTrackingResponse==null && timerTries>0)
            {
                return new EnrollmentResult
                {
                    Status = 30, //failure
                    StatusMessage = $"Certificate may still waiting on Hydrant and is not ready for download"
                };
            }

            var cert = GetSingleRecord(csrTrackingResponse.Id.ToString());
            return _requestManager.GetEnrollmentResult(csrTrackingResponse,cert);
        }

        private Certificate GetCertificateOnTimer(string Id)
        {
            //Get the csr tracking response from the tracking Id returned from Enrollment
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Certificate csrTrackingResponse = null;

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(30) && csrTrackingResponse == null)
            {
                try
                {
                    csrTrackingResponse =
                    Task.Run(async () => await HydrantIdClient.GetSubmitGetCertificateByCsrAsync(Id))
                        .Result;
                }
                catch (System.AggregateException e)
                {
                    Logger.Trace($"Enrollment Response Not Available Yet, try again {LogHandler.FlattenException(e)}.");
                }
                Thread.Sleep(1000);
            }

            return csrTrackingResponse;
        }

        public override CAConnectorCertificate GetSingleRecord(string caRequestId)
        {
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
            Logger.Trace($"Keyfactor Ca Id: {caRequestId}");
            try
            {
                var certificateResponse =
                    Task.Run(async () =>
                            await HydrantIdClient.GetSubmitGetCertificateAsync(caRequestId.Substring(0, 36)))
                        .Result;

                Logger.Trace($"Single Cert JSON: {JsonConvert.SerializeObject(certificateResponse)}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
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
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                HydrantIdClient = new HydrantIdClient(configProvider);
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdProxy.Initialize: {e.Message}");
                throw;
            }
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