using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAProxy.AnyGateway.Interfaces;
using CSS.Common.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using HawkNet;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Exceptions;
using Keyfactor.HydrantId.Interfaces;
using HawkCredential = HawkNet.HawkCredential;
using Keyfactor.HydrantId.Extensions;

namespace Keyfactor.HydrantId.Client
{
    public sealed class HydrantIdClient : LoggingClientBase
    {
        public HydrantIdClient(ICAConnectorConfigProvider config)
        {
            if (config.CAConnectionData.ContainsKey(Constants.HydrantIdAuthId))
            {
                ConfigProvider = config;
                RequestManager=new RequestManager();
            }
        }

        private Uri BaseUrl { get; set; }
        private int PageSize { get; set; } = 100;
        private string ApiId { get; set; }
        private RequestManager RequestManager { get; set; }

        private ICAConnectorConfigProvider ConfigProvider { get; set; }

        public async Task<CertRequestStatus> GetSubmitEnrollmentAsync(
            CertRequestBody registerRequest)
        {
            var apiEndpoint = $"/api/v2/csr";
            var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);

            using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                JsonConvert.SerializeObject(registerRequest), Encoding.ASCII, "application/json")))
            {
                Logger.Trace(JsonConvert.SerializeObject(registerRequest));
                var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var registrationResponse =
                    JsonConvert.DeserializeObject<CertRequestStatus>(await resp.Content.ReadAsStringAsync(),
                        settings);
                return registrationResponse;
            }
        }


        public async Task<Certificate> GetSubmitGetCertificateAsync(string certificateId)
        {
            var apiEndpoint = $"/api/v2/certificates/{certificateId}";
            var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);

            using (var resp = await restClient.GetAsync(apiEndpoint))
            {
                resp.EnsureSuccessStatusCode();
                var getCertificateResponse =
                    JsonConvert.DeserializeObject<Certificate>(await resp.Content.ReadAsStringAsync());
                return getCertificateResponse;
            }
        }

        public async Task<RevokeCertificateReasonIssuerDn> GetSubmitRevokeCertificateAsync(string uuId)
        {
            var apiEndpoint = $"/api/v2/certificates/{uuId}";
            var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);

            using (var resp = await restClient.PatchAsync(new Uri(BaseUrl + apiEndpoint), new StringContent("")))
            {
                var jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var getRevokeResponse =
                    JsonConvert.DeserializeObject<RevokeCertificateReasonIssuerDn>(await resp.Content.ReadAsStringAsync(), jsonSerializerSettings);
                return getRevokeResponse;
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
                    pageCounter++;
                    var queryOrderRequest = RequestManager.GetCertificatesListRequest(pageCounter, PageSize);
                    var batchItemsProcessed = 0;

                    var apiEndpoint = "/api/v2/certificates";
                    var restClient = ConfigureRestClient("post",BaseUrl + apiEndpoint);

                    using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                        JsonConvert.SerializeObject(queryOrderRequest), Encoding.ASCII, "application/json")))
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

                        if (batchResponse != null)
                        {
                            var batchCount = batchResponse.Count;

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
        private HttpClient ConfigureRestClient(string method,string url)
        {

            BaseUrl = new Uri(ConfigProvider.CAConnectionData[Constants.HydrantIdBaseUrl].ToString());
            ApiId= ConfigProvider.CAConnectionData[Constants.HydrantIdAuthId].ToString();

            var credentials = new HawkCredential
            {
                Id = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthId].ToString(),
                Key = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthKey].ToString(),
                Algorithm = "sha256"
            };

            var byteArray = new byte[20];
            //Generate a cryptographically random set of bytes
            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(byteArray);
            }

            var nOnce = Convert.ToBase64String(byteArray);
            var date = DateTime.Now;
            var ts = Hawk.ConvertToUnixTimestamp(date);
            var mac = Hawk.CalculateMac(BaseUrl.Host + ":" + BaseUrl.Port, method, new Uri(url), "", ts.ToString(CultureInfo.InvariantCulture), nOnce, credentials, "header");
            var authorization =
                $"id=\"{ApiId}\", ts=\"{ts}\", nonce=\"{nOnce}\", mac=\"{mac}\"";

            var clientHandler = new WebRequestHandler();
            var returnClient = new HttpClient(clientHandler, true) { BaseAddress = BaseUrl };
            returnClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            returnClient.DefaultRequestHeaders.Add("Authorization", "Hawk " + authorization);
            return returnClient;
        }

    }
}