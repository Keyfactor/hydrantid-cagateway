using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAProxy.AnyGateway.Interfaces;
using CSS.Common.Logging;
using HawkNet;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Exceptions;
using Keyfactor.HydrantId.Extensions;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Keyfactor.HydrantId.Client
{
    public sealed class HydrantIdClient : LoggingClientBase
    {
        public HydrantIdClient(ICAConnectorConfigProvider config)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                if (config.CAConnectionData.ContainsKey(Constants.HydrantIdAuthId))
                {
                    ConfigProvider = config;
                    BaseUrl = ConfigProvider.CAConnectionData[Constants.HydrantIdBaseUrl].ToString();
                    RequestManager = new RequestManager();
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.HydrantIdClient: {e.Message}");
                throw;
            }
        }

        private string BaseUrl { get; }
        private int PageSize { get; } = 100;
        private string ApiId { get; set; }
        private RequestManager RequestManager { get; }

        private ICAConnectorConfigProvider ConfigProvider { get; }

        public async Task<CertRequestResult> GetSubmitEnrollmentAsync(
            CertRequestBody registerRequest)
        {
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
            var apiEndpoint = "/api/v2/csr";
            Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
            var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);
            var traceWriter = new MemoryTraceWriter();

            using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json")))
            {
                try
                {
                    Logger.Trace($"Register Request JSON: {JsonConvert.SerializeObject(registerRequest)}");
                    var settings = new JsonSerializerSettings
                        {NullValueHandling = NullValueHandling.Ignore, TraceWriter = traceWriter};
                    var _ = await resp.Content.ReadAsStringAsync();

                    if (resp.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var errorResponse =
                            JsonConvert.DeserializeObject<ErrorReturn>(await resp.Content.ReadAsStringAsync(),
                                settings);
                        Logger.Error($"Error Response JSON: {JsonConvert.SerializeObject(errorResponse)}");
                        var responseReturn = new CertRequestResult {ErrorReturn = errorResponse, RequestStatus = null};
                        return responseReturn;
                    }

                    var validResponse =
                        JsonConvert.DeserializeObject<CertRequestStatus>(await resp.Content.ReadAsStringAsync(),
                            settings);
                    Logger.Error($"validResponse Response JSON: {JsonConvert.SerializeObject(validResponse)}");
                    var validReturn = new CertRequestResult {ErrorReturn = null, RequestStatus = validResponse};
                    return validReturn;
                }
                catch (Exception e)
                {
                    Logger.Error($"Error Occured in HydrantIdClient.GetSubmitEnrollmentAsync: {e.Message}");
                    throw;
                }
            }
        }


        public async Task<CertRequestResult> GetSubmitRenewalAsync(string certificateId,
            RenewalRequest renewRequest)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var apiEndpoint = $"/api/v2/certificates/{certificateId}/renew";
                var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);
                Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
                var traceWriter = new MemoryTraceWriter();

                using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                    JsonConvert.SerializeObject(renewRequest), Encoding.UTF8, "application/json")))
                {
                    Logger.Trace($"Renew Request: {JsonConvert.SerializeObject(renewRequest)}");
                    var settings = new JsonSerializerSettings
                        { NullValueHandling = NullValueHandling.Ignore, TraceWriter = traceWriter };
                    var _ = await resp.Content.ReadAsStringAsync();

                    if (resp.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var errorResponse =
                            JsonConvert.DeserializeObject<ErrorReturn>(await resp.Content.ReadAsStringAsync(),
                                settings);
                        Logger.Error($"Error Response JSON: {JsonConvert.SerializeObject(errorResponse)}");
                        var responseReturn = new CertRequestResult { ErrorReturn = errorResponse, RequestStatus = null };
                        return responseReturn;
                    }

                    var validResponse =
                        JsonConvert.DeserializeObject<CertRequestStatus>(await resp.Content.ReadAsStringAsync(),
                            settings);
                    Logger.Error($"validResponse Response JSON: {JsonConvert.SerializeObject(validResponse)}");
                    var validReturn = new CertRequestResult { ErrorReturn = null, RequestStatus = validResponse };
                    return validReturn;
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.GetSubmitRenewalAsync: {e.Message}");
                throw;
            }
        }


        public async Task<List<Policy>> GetPolicyList()
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var apiEndpoint = "/api/v2/policies";
                Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
                var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);

                var traceWriter = new MemoryTraceWriter();

                using (var resp = await restClient.GetAsync(apiEndpoint))
                {
                    var settings = new JsonSerializerSettings
                        {NullValueHandling = NullValueHandling.Ignore, TraceWriter = traceWriter};
                    var policiesResponse =
                        JsonConvert.DeserializeObject<List<Policy>>(await resp.Content.ReadAsStringAsync(),
                            settings);
                    Logger.Debug(traceWriter.ToString());
                    return policiesResponse;
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.GetPolicyList: {e.Message}");
                throw;
            }
        }


        public async Task<Certificate> GetSubmitGetCertificateAsync(string certificateId)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var apiEndpoint = $"/api/v2/certificates/{certificateId}";
                Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
                var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);

                using (var resp = await restClient.GetAsync(apiEndpoint))
                {
                    resp.EnsureSuccessStatusCode();
                    var getCertificateResponse =
                        JsonConvert.DeserializeObject<Certificate>(await resp.Content.ReadAsStringAsync());
                    return getCertificateResponse;
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.GetSubmitGetCertificateAsync: {e.Message}");
                throw;
            }
        }

        public async Task<Certificate> GetSubmitGetCertificateByCsrAsync(string requestTrackingId)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var apiEndpoint = $"/api/v2/csr/{requestTrackingId}/certificate";
                Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
                var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);

                using (var resp = await restClient.GetAsync(apiEndpoint))
                {
                    resp.EnsureSuccessStatusCode();
                    var getCertificateResponse =
                        JsonConvert.DeserializeObject<Certificate>(await resp.Content.ReadAsStringAsync());
                    return getCertificateResponse;
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.GetSubmitGetCertificateAsync: {e.Message}");
                throw;
            }
        }

        public async Task<CertificateStatus> GetSubmitRevokeCertificateAsync(string hydrantId,
            RevocationReasons revokeReason)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var apiEndpoint = $"/api/v2/certificates/{hydrantId}";
                Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
                var restClient = ConfigureRestClient("patch", BaseUrl + apiEndpoint);
                var revokeRequest = RequestManager.GetRevokeRequest(revokeReason);
                Logger.Trace($"Revoke Request JSON: {JsonConvert.SerializeObject(revokeRequest)}");
                using (var resp = await restClient.PatchAsync(new Uri(BaseUrl + apiEndpoint), new StringContent(
                    JsonConvert.SerializeObject(revokeRequest), Encoding.UTF8, "application/json")))
                {
                    var jsonSerializerSettings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
                    var getRevokeResponse =
                        JsonConvert.DeserializeObject<CertificateStatus>(await resp.Content.ReadAsStringAsync(),
                            jsonSerializerSettings);
                    Logger.Trace($"Revoke Response JSON: {JsonConvert.SerializeObject(getRevokeResponse)}");
                    return getRevokeResponse;
                }
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.GetSubmitRevokeCertificateAsync: {e.Message}");
                throw;
            }
        }

        public async Task GetSubmitCertificateListRequestAsync(BlockingCollection<ICertificatesResponseItem> bc,
            CancellationToken ct)
        {
            Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
            try
            {
                var itemsProcessed = 0;
                var pageCounter = 0;
                var isComplete = false;
                var retryCount = 0;
                do
                {
                    Logger.Trace($"pageCounter: {pageCounter}  pageSize: {PageSize}");
                    var queryOrderRequest = RequestManager.GetCertificatesListRequest(pageCounter, PageSize);
                    Logger.Trace($"queryOrderRequest JSON: {JsonConvert.SerializeObject(queryOrderRequest)}");
                    var batchItemsProcessed = 0;

                    var apiEndpoint = "/api/v2/certificates";
                    Logger.Trace($"API Url {BaseUrl + apiEndpoint}");
                    var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);

                    using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                        JsonConvert.SerializeObject(queryOrderRequest), Encoding.UTF8, "application/json"), ct))
                    {
                        if (!resp.IsSuccessStatusCode)
                        {
                            var responseMessage = resp.Content.ReadAsStringAsync().Result;
                            Logger.Error(
                                $"Failed Request to Keyfactor. Retrying request. Status Code {resp.StatusCode} | Message: {responseMessage}");
                            retryCount++;
                            if (retryCount > 5)
                                throw new RetryCountExceededException(
                                    $"5 consecutive failures to {resp.RequestMessage.RequestUri}");

                            continue;
                        }

                        var stringResponse = await resp.Content.ReadAsStringAsync();

                        var batchResponse =
                            JsonConvert.DeserializeObject<CertificatesResponse>(stringResponse);

                        Logger.Trace($"batchResponse JSON: {JsonConvert.SerializeObject(batchResponse)}");

                        if (batchResponse != null)
                        {
                            var batchCount = batchResponse.Items.Count;

                            Logger.Trace($"Processing {batchCount} items in batch");
                            do
                            {
                                var r = batchResponse.Items[batchItemsProcessed];
                                if (bc.TryAdd(r, 10, ct))
                                {
                                    Logger.Trace($"Added Template ID {r.Id} to Queue for processing");
                                    batchItemsProcessed++;
                                    itemsProcessed++;
                                    Logger.Trace($"Processed {batchItemsProcessed} of {batchCount}");
                                    Logger.Trace($"Total Items Processed: {itemsProcessed}");
                                }
                                else
                                {
                                    Logger.Trace($"Adding {r} blocked. Retry");
                                }
                            } while (batchItemsProcessed < batchCount); //batch loop
                        }
                    }

                    //assume that if we process less records than requested that we have reached the end of the certificate list
                    if (batchItemsProcessed < PageSize)
                        isComplete = true;
                    pageCounter = pageCounter + PageSize;
                } while (!isComplete); //page loop

                bc.CompleteAdding();
            }
            catch (OperationCanceledException cancelEx)
            {
                Logger.Warn($"Synchronize method was cancelled. Message: {cancelEx.Message}");
                bc.CompleteAdding();
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
                // ReSharper disable once PossibleIntendedRethrow
                throw cancelEx;
            }
            catch (RetryCountExceededException retryEx)
            {
                Logger.Error($"Retries Failed: {retryEx.Message}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
            }
            catch (HttpRequestException ex)
            {
                Logger.Error($"HttpRequest Failed: {ex.Message}");
                Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
            }

            Logger.MethodExit(ILogExtensions.MethodLogLevel.Debug);
        }

        // ReSharper disable once InconsistentNaming
        private HttpClient ConfigureRestClient(string method, string url)
        {
            try
            {
                Logger.MethodEntry(ILogExtensions.MethodLogLevel.Debug);
                var bUrl = new Uri(BaseUrl);
                ApiId = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthId].ToString();

                var credentials = new HawkCredential
                {
                    Id = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthId].ToString(),
                    Key = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthKey].ToString(),
                    Algorithm = "sha256"
                };

                Logger.Trace($"HawkCredential JSON: {JsonConvert.SerializeObject(credentials)}");

                var byteArray = new byte[20];
                //Generate a cryptographically random set of bytes
                using (var rnd = RandomNumberGenerator.Create())
                {
                    rnd.GetBytes(byteArray);
                }

                var nOnce = Convert.ToBase64String(byteArray);
                var date = DateTime.Now;
                var ts = Hawk.ConvertToUnixTimestamp(date);
                var mac = Hawk.CalculateMac(bUrl.Host + ":" + bUrl.Port, method, new Uri(url), "",
                    ts.ToString(CultureInfo.InvariantCulture), nOnce, credentials, "header");
                var authorization =
                    $"id=\"{ApiId}\", ts=\"{ts}\", nonce=\"{nOnce}\", mac=\"{mac}\"";

                Logger.Trace($"Authorization: {authorization}");

                var clientHandler = new WebRequestHandler();
                var returnClient = new HttpClient(clientHandler, true) {BaseAddress = bUrl};
                returnClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                returnClient.DefaultRequestHeaders.Add("Authorization", "Hawk " + authorization);
                return returnClient;
            }
            catch (Exception e)
            {
                Logger.Error($"Error Occured in HydrantIdClient.ConfigureRestClient: {e.Message}");
                throw;
            }
        }
    }
}