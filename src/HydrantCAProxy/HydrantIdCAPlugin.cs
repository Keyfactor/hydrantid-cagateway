using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Interfaces;
using Keyfactor.HydrantId;
using Keyfactor.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LogHandler = Keyfactor.Logging.LogHandler;
using Keyfactor.HydrantId.Client.Models;
using System.Diagnostics;
using Keyfactor.AnyGateway.Extensions;
using Keyfactor.PKI;
using System.Data;
using System.Drawing;
using Keyfactor.PKI.Enums.EJBCA;

namespace Keyfactor.Extensions.CAPlugin.HydrantId
{
    public class HydrantIdCAPlugin : IAnyCAPlugin
    {
        private static readonly ILogger _logger = LogHandler.GetClassLogger<HydrantIdCAPlugin>();
        private RequestManager _requestManager;
        private IAnyCAPluginConfigProvider Config { get; set; }
        private ICertificateDataReader certDataReader;

        public void Initialize(IAnyCAPluginConfigProvider configProvider, ICertificateDataReader certificateDataReader)
        {
            _logger.MethodEntry();
            try
            {
                certDataReader= certificateDataReader;
                Config = configProvider;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to initialize GCP CAS CAPlugin: {ex}");
            }
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

        public async Task Ping()
        {

        }

        public Task ValidateCAConnectionInfo(Dictionary<string, object> connectionInfo)
        {
            _logger.MethodEntry();
            _logger.LogDebug($"Validating GCP CAS CA Connection properties");
            var rawData = JsonConvert.SerializeObject(connectionInfo);
            HydrantIdCAPluginConfig.Config config = JsonConvert.DeserializeObject<HydrantIdCAPluginConfig.Config>(rawData);

            _logger.LogTrace($"HydrantIdClientFromCAConnectionData - HydrantIdBaseUrl: {config.HydrantIdBaseUrl}");
            _logger.LogTrace($"HydrantIdClientFromCAConnectionData - HydrantIdAuthId: {config.HydrantIdAuthId}");
            _logger.LogTrace($"HydrantIdClientFromCAConnectionData - HydrantIdAuthKey: {config.HydrantIdAuthKey}");

            List<string> missingFields = new List<string>();

            if (string.IsNullOrEmpty(config.HydrantIdBaseUrl)) missingFields.Add(nameof(config.HydrantIdBaseUrl));
            if (string.IsNullOrEmpty(config.HydrantIdAuthId)) missingFields.Add(nameof(config.HydrantIdAuthId));
            if (string.IsNullOrEmpty(config.HydrantIdAuthKey)) missingFields.Add(nameof(config.HydrantIdAuthKey));

            if (missingFields.Count > 0)
            {
                throw new ArgumentException($"The following required fields are missing or empty: {string.Join(", ", missingFields)}");
            }

            _logger.MethodExit();
             return Ping();
        }

        public Task ValidateProductInfo(EnrollmentProductInfo productInfo, Dictionary<string, object> connectionInfo)
        {
            _logger.MethodEntry();
            //TODO: Evaluate Template (if avaiable) based on ProductInfo
            _logger.MethodExit();
            return Task.CompletedTask;
        }


        public List<string> GetProductIds()
        {
            var client = new HydrantIdClient(Config);
            var policies = client.GetPolicyList().GetAwaiter().GetResult();

            var ids = policies
                .Where(p => p.Id.HasValue)
                .Select(p => p.Name.ToString())
                .ToList();

            return ids;
        }

        public async Task Synchronize(BlockingCollection<AnyCAPluginCertificate> blockingBuffer, DateTime? lastSync, bool fullSync, CancellationToken cancelToken)
        {
            _logger.MethodEntry();
            _requestManager = new RequestManager();

            var certs = new BlockingCollection<ICertificatesResponseItem>(100);
            var client = new HydrantIdClient(Config);

            _ = client.GetSubmitCertificateListRequestAsync(certs, cancelToken);

            try
            {
                foreach (var item in certs.GetConsumingEnumerable(cancelToken))
                {
                    cancelToken.ThrowIfCancellationRequested();

                    if (item == null)
                        continue;

                    _logger.LogTrace($"Took Certificate ID {item.Id} from Queue");

                    var certStatus = _requestManager.GetMapReturnStatus(item.RevocationStatus);
                    _logger.LogTrace($"Numeric Status: {certStatus}");

                    if (certStatus != Convert.ToInt32(EndEntityStatus.GENERATED) &&
                        certStatus != Convert.ToInt32(EndEntityStatus.REVOKED))
                        continue;

                    _logger.LogTrace($"Product Id: {item.Policy.Name}");

                    try
                    {
                        var cert = await client.GetSubmitGetCertificateAsync(item.Id);
                        var fileContent = cert.Pem ?? string.Empty;

                        if (string.IsNullOrWhiteSpace(fileContent))
                            continue;

                        var certsClean = fileContent
                            .Replace("\n", string.Empty)
                            .Split(new[] { "-----END CERTIFICATE-----", "-----BEGIN CERTIFICATE-----" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var certStr in certsClean)
                        {
                            try
                            {
                                var x509Cert = new X509Certificate2(Encoding.ASCII.GetBytes(certStr));
                                var requestId = $"{item.Id}-{x509Cert.SerialNumber}";

                                blockingBuffer.Add(new AnyCAPluginCertificate
                                {
                                    CARequestID = item.Id,
                                    Certificate = certStr,
                                    Status = certStatus,
                                    ProductID = item.Policy.Name
                                }, cancelToken);

                                _logger.LogTrace($"Processed cert with serial {x509Cert.SerialNumber}");
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError($"Error parsing cert: {ex.Message}, ID: {item.Id}, CN: {item.CommonName}, Serial: {item.Serial}");
                            }
                        }
                    }
                    catch (Exception certEx)
                    {
                        _logger.LogError($"Failed to retrieve or process cert {item.Id}: {certEx.Message}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogError("Synchronize was canceled.");
            }
            catch (AggregateException)
            {
                _logger.LogError("Csc Global Synchronize Task failed!");
                throw;
            }
            finally
            {
                _logger.MethodExit();
            }
        }

        public async Task<EnrollmentResult> Enroll(string csr, string subject, Dictionary<string, string[]> san, EnrollmentProductInfo productInfo, RequestFormat requestFormat, EnrollmentType enrollmentType)
        {
            _logger.MethodEntry();
            _requestManager = new RequestManager();
            int timerTries = 0;
            Certificate csrTrackingResponse = null;
            var client = new HydrantIdClient(Config);

            try
            {
                CertRequestResult enrollmentResponse = null;

                if (enrollmentType == EnrollmentType.New)
                {
                    _logger.LogTrace("Entering New Enrollment");
                    var policyListResult = await client.GetPolicyList();
                    _logger.LogTrace($"Policy Result List: {JsonConvert.SerializeObject(policyListResult)}");

                    var policyId = policyListResult.Single(p => p.Name.Equals(productInfo.ProductID));
                    _logger.LogTrace($"PolicyId: {JsonConvert.SerializeObject(policyId)}");

                    var enrollmentRequest = _requestManager.GetEnrollmentRequest(policyId.Id, productInfo, csr, san);
                    _logger.LogTrace($"Enrollment Request JSON: {JsonConvert.SerializeObject(enrollmentRequest)}");

                    enrollmentResponse = await client.GetSubmitEnrollmentAsync(enrollmentRequest);
                }
                else if (enrollmentType == EnrollmentType.RenewOrReissue)
                {
                    _logger.LogTrace("Entering Renew/Reissue Logic...");

                    var sn = productInfo.ProductParameters["PriorCertSN"];
                    _logger.LogTrace($"Prior Cert Serial Number: {sn}");

                    var certificateId = await certDataReader.GetRequestIDBySerialNumber(sn);

                    //1) Get Single Certificate for the previous certificate
                    var previousCert = await GetSingleRecord(certificateId);

                    //2) Look up the Expiration Date for that cert
                    var previousX509 = new X509Certificate2(Encoding.ASCII.GetBytes(previousCert.Certificate));
                    var expiration = previousX509.NotAfter;
                    var now = DateTime.UtcNow;

                    //3) Determine if it is a Renewal vs Re-Issue
                    var isRenewal = (expiration - now).TotalDays <= Convert.ToInt16(productInfo.ProductParameters["RenewalDays"]);
                    _logger.LogTrace($"Certificate Expiration: {expiration}, Current Time: {now}, IsRenewal: {isRenewal}");

                    if (isRenewal)
                    {
                        _logger.LogTrace("Proceeding with Renewal Request...");
                        var renewRequest = _requestManager.GetRenewalRequest(csr, false);
                        _logger.LogTrace($"Renewal Request JSON: {JsonConvert.SerializeObject(renewRequest)}");
                        enrollmentResponse = await client.GetSubmitRenewalAsync(certificateId, renewRequest);
                    }
                    else
                    {
                        _logger.LogTrace("Proceeding with Re-Issue Request...");
                        var policyListResult = await client.GetPolicyList();
                        var policyId = policyListResult.Single(p => p.Name.Equals(productInfo.ProductID));
                        var reissueRequest = _requestManager.GetEnrollmentRequest(policyId.Id, productInfo, csr, san);
                        _logger.LogTrace($"Re-Issue Request JSON: {JsonConvert.SerializeObject(reissueRequest)}");
                        enrollmentResponse = await client.GetSubmitEnrollmentAsync(reissueRequest);
                    }
                }

                if (enrollmentResponse?.ErrorReturn?.Status == "Failure")
                {
                    return new EnrollmentResult
                    {
                        Status = (int)EndEntityStatus.FAILED,
                        StatusMessage = $"Enrollment Failed with error {enrollmentResponse.ErrorReturn.Error}"
                    };
                }

                timerTries++;
                csrTrackingResponse = await GetCertificateOnTimerAsync(enrollmentResponse?.RequestStatus?.Id);

                if (csrTrackingResponse == null)
                {
                    return new EnrollmentResult
                    {
                        Status = (int)EndEntityStatus.FAILED,
                        StatusMessage = "Certificate may still be pending in Hydrant and is not ready for download"
                    };
                }

                var cert = await GetSingleRecord(csrTrackingResponse.Id.ToString());

                var result = _requestManager.GetEnrollmentResult(csrTrackingResponse, cert);
                return result;
            }
            finally
            {
                _logger.MethodExit();
            }
        }

        public async Task<int> Revoke(string caRequestID, string hexSerialNumber, uint revocationReason)
        {
            _logger.MethodEntry();
            _requestManager = new RequestManager();

            try
            {
                _logger.LogTrace("Starting Revoke Method");

                var client = new HydrantIdClient(Config);
                var hydrantId = caRequestID.Substring(0, 36);
                var revokeReason = _requestManager.GetMapRevokeReasons(revocationReason);

                _logger.LogTrace($"Revoke Reason: {revokeReason}");

                var revokeResponse = await client.GetSubmitRevokeCertificateAsync(hydrantId, revokeReason);
                _logger.LogTrace($"Revoke Response JSON: {JsonConvert.SerializeObject(revokeResponse)}");

                return (int)EndEntityStatus.REVOKED;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during revoke process: {e.Message}");
                return (int)EndEntityStatus.FAILED;
            }
            finally
            {
                _logger.MethodExit();
            }
        }

        private async Task<Certificate> GetCertificateOnTimerAsync(string id)
        {
            var stopwatch = Stopwatch.StartNew();
            var client = new HydrantIdClient(Config);

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(30))
            {
                try
                {
                    var result = await client.GetSubmitGetCertificateByCsrAsync(id);
                    if (result != null)
                        return result;
                }
                catch (Exception e)
                {
                    _logger.LogTrace($"Enrollment Response not available yet: {LogHandler.FlattenException(e)}");
                }

                await Task.Delay(1000);
            }

            return null;
        }

        public async Task<AnyCAPluginCertificate> GetSingleRecord(string caRequestID)
        {
            _logger.MethodEntry();
            _requestManager = new RequestManager();
            _logger.LogTrace($"Keyfactor CA ID: {caRequestID}");

            try
            {
                var client = new HydrantIdClient(Config);
                var certId = caRequestID.Substring(0, 36);
                var certificateResponse = await client.GetSubmitGetCertificateAsync(certId);

                _logger.LogTrace($"Single Cert JSON: {JsonConvert.SerializeObject(certificateResponse)}");
                _logger.MethodExit();

                return new AnyCAPluginCertificate
                {
                    CARequestID = caRequestID,
                    Certificate = certificateResponse.Pem,
                    Status = _requestManager.GetMapReturnStatus(certificateResponse.RevocationStatus),
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Could not retrieve cert for CARequestID {caRequestID}: {ex.Message}");

                return new AnyCAPluginCertificate
                {
                    CARequestID = caRequestID,
                    Status = _requestManager.GetMapReturnStatus(0) // Failed
                };
            }
        }

        public Dictionary<string, PropertyConfigInfo> GetCAConnectorAnnotations()
        {
            _logger.MethodEntry();
            _logger.MethodExit();
            return HydrantIdCAPluginConfig.GetPluginAnnotations();
        }

        public Dictionary<string, PropertyConfigInfo> GetTemplateParameterAnnotations()
        {
            _logger.MethodEntry();
            _logger.MethodExit();
            return HydrantIdCAPluginConfig.GetTemplateParameterAnnotations();
        }

    }
}