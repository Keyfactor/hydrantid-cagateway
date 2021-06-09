﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CAProxy.AnyGateway;
using CAProxy.AnyGateway.Interfaces;
using CAProxy.AnyGateway.Models;
using CAProxy.Common;
using CSS.Common;
using CSS.Common.Logging;
using CSS.PKI;
using Keyfactor.HydrantId.Api;
using Keyfactor.HydrantId.Model;
using Keyfactor.HydrantId.Model.Enums;

namespace Keyfactor.HydrantId
{
    public class HydrantIdProxy : BaseCAConnector
    {

        public HydrantIdProxy()
        {

        }

        public CertificatesApi CertApi { get; set; }
        public bool EnableTemplateSync { get; set; }

        public override int Revoke(string caRequestId, string hexSerialNumber, uint revocationReason)
        {
            try
            {
                Logger.Trace($"Staring Revoke Method");
                
                RevokeCertificateReason revoke=new RevokeCertificateReason(RevocationReasons.CessationOfOperation);

                var revokeResponse =
                    Task.Run(async () =>
                            await CertApi.CertificatesIdPatchAsync(revoke, caRequestId))
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
            /* 
 Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
 try
 {
     var certs = new BlockingCollection<>(100);
     CscGlobalClient.SubmitCertificateListRequestAsync(certs, cancelToken);

     foreach (var currentResponseItem in certs.GetConsumingEnumerable(cancelToken))
     {
         if (cancelToken.IsCancellationRequested)
         {
             Logger.Error("Synchronize was canceled.");
             break;
         }

         try
         {
             Logger.Trace($"Took Certificate ID {currentResponseItem?.Uuid} from Queue");
             var certStatus = _requestManager.MapReturnStatus(currentResponseItem?.Status);

             //Keyfactor sync only seems to work when there is a valid cert and I can only get Active valid certs from Csc Global
             if (certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.ISSUED) ||
                 certStatus == Convert.ToInt32(PKIConstants.Microsoft.RequestDisposition.REVOKED))
             {
                 //One click renewal/reissue won't work for this implementation so there is an option to disable it by not syncing back template
                 var productId = "CscGlobal";
                 if (EnableTemplateSync) productId = currentResponseItem?.CertificateType;

                 var fileContent =
                     Encoding.ASCII.GetString(
                         Convert.FromBase64String(currentResponseItem?.Certificate ?? string.Empty));
                 var fileContent2 =
                     Encoding.UTF8.GetString(
                         Convert.FromBase64String(fileContent)); //Double base64 Encoded for some reason

                 Logger.Trace($"Certificate Content: {fileContent2}");

                 if (fileContent2.Length > 0)
                 {
                     var certData = fileContent2.Replace("\r\n", string.Empty);
                     var splitCerts =
                         certData.Split(new[] {"-----END CERTIFICATE-----", "-----BEGIN CERTIFICATE-----"},
                             StringSplitOptions.RemoveEmptyEntries);
                     foreach (var cert in splitCerts)
                         if (!cert.Contains(".crt"))
                         {
                             Logger.Trace($"Split Cert Value: {cert}");

                             var currentCert = new X509Certificate2(Encoding.ASCII.GetBytes(cert));
                             if (!currentCert.Subject.Contains("AAA Certificate Services") &&
                                 !currentCert.Subject.Contains("USERTrust RSA Certification Authority") &&
                                 !currentCert.Subject.Contains("Trusted Secure Certificate Authority 5"))
                                 blockingBuffer.Add(new CAConnectorCertificate
                                 {
                                     CARequestID =
                                         $"{currentResponseItem?.Uuid}-{currentCert.SerialNumber}",
                                     Certificate = cert,
                                     SubmissionDate = Convert.ToDateTime(currentResponseItem?.OrderDate),
                                     Status = certStatus,
                                     ProductID = productId
                                 }, cancelToken);
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
            */
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
            /*
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);

            RegistrationRequest enrollmentRequest;
            CAConnectorCertificate priorCert;
            ReissueRequest reissueRequest;
            RenewalRequest renewRequest;

            string uUId;
            switch (enrollmentType)
            {
                case RequestUtilities.EnrollmentType.New:
                    Logger.Trace($"Entering New Enrollment");
                    //If they renewed an expired cert it gets here and this will not be supported
                    IRegistrationResponse enrollmentResponse;
                    if (!productInfo.ProductParameters.ContainsKey("PriorCertSN"))
                    {
                        enrollmentRequest = _requestManager.GetRegistrationRequest(productInfo, csr, san);
                        Logger.Trace($"Enrollment Request JSON: {JsonConvert.SerializeObject(enrollmentRequest)}");
                        enrollmentResponse =
                            Task.Run(async () => await CscGlobalClient.SubmitRegistrationAsync(enrollmentRequest))
                                .Result;
                        Logger.Trace($"Enrollment Response JSON: {JsonConvert.SerializeObject(enrollmentResponse)}");
                    }
                    else
                    {
                        return new EnrollmentResult
                        {
                            Status = 30, //failure
                            StatusMessage = "You cannot renew and expired cert please perform an new enrollment."
                        };
                    }
                    Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                    return _requestManager.GetEnrollmentResult(enrollmentResponse);
                case RequestUtilities.EnrollmentType.Renew:
                    Logger.Trace($"Entering Renew Enrollment");
                    priorCert = certificateDataReader.GetCertificateRecord(
                        DataConversion.HexToBytes(productInfo.ProductParameters["PriorCertSN"]));
                    uUId = priorCert.CARequestID.Substring(0, 36); //uUId is a GUID
                    Logger.Trace($"Renew uUId: {uUId}");
                    renewRequest = _requestManager.GetRenewalRequest(productInfo, uUId, csr, san);
                    Logger.Trace($"Renewal Request JSON: {JsonConvert.SerializeObject(renewRequest)}");
                    var renewResponse = Task.Run(async () => await CscGlobalClient.SubmitRenewalAsync(renewRequest))
                        .Result;
                    Logger.Trace($"Renewal Response JSON: {JsonConvert.SerializeObject(renewResponse)}");
                    Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                    return _requestManager.GetRenewResponse(renewResponse);

                case RequestUtilities.EnrollmentType.Reissue:
                    Logger.Trace($"Entering Reissue Enrollment");
                    priorCert = certificateDataReader.GetCertificateRecord(
                        DataConversion.HexToBytes(productInfo.ProductParameters["PriorCertSN"]));
                    uUId = priorCert.CARequestID.Substring(0, 36); //uUId is a GUID
                    Logger.Trace($"Reissue uUId: {uUId}");
                    reissueRequest = _requestManager.GetReissueRequest(productInfo, uUId, csr, san);
                    Logger.Trace($"Reissue JSON: {JsonConvert.SerializeObject(reissueRequest)}");
                    var reissueResponse = Task.Run(async () => await CscGlobalClient.SubmitReissueAsync(reissueRequest))
                        .Result;
                    Logger.Trace($"Reissue Response JSON: {JsonConvert.SerializeObject(reissueResponse)}");
                    Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                    return _requestManager.GetReIssueResult(reissueResponse);
            }
            Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
            return null;
            */
            return new EnrollmentResult
            {
                Status = 30, //failure
                StatusMessage = "You cannot renew and expired cert please perform an new enrollment."
            };
        }


        
        public override CAConnectorCertificate GetSingleRecord(string caRequestId)
        {
            /* Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
             var keyfactorCaId = caRequestId.Substring(38); //todo fix to use pipe delimiter
             Logger.Trace($"Keyfactor Ca Id: {keyfactorCaId}");
             var certificateResponse =
                 Task.Run(async () => await CscGlobalClient.SubmitGetCertificateAsync(caRequestId.Substring(0, 36)))
                     .Result;

             Logger.Trace($"Single Cert JSON: {JsonConvert.SerializeObject(certificateResponse)}");
             Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
             return new CAConnectorCertificate
             {
                 CARequestID = keyfactorCaId,
                 Certificate = certificateResponse.Certificate,
                 ResolutionDate = Convert.ToDateTime(certificateResponse.EffectiveDate),
                 Status = _requestManager.MapReturnStatus(certificateResponse.Status),
                 SubmissionDate = Convert.ToDateTime(certificateResponse.OrderDate)
             };*/
            return new CAConnectorCertificate();
        }

        public override void Initialize(ICAConnectorConfigProvider configProvider)
        {
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
            CertApi = new CertificatesApi();
            var templateSync = configProvider.CAConnectionData["TemplateSync"].ToString();
            if (templateSync.ToUpper() == "ON") EnableTemplateSync = true;
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