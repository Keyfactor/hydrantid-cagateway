// Copyright 2025 Keyfactor                                                   
// Licensed under the Apache License, Version 2.0 (the "License"); you may    
// not use this file except in compliance with the License.  You may obtain a 
// copy of the License at http://www.apache.org/licenses/LICENSE-2.0.  Unless 
// required by applicable law or agreed to in writing, software distributed   
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES   
// OR CONDITIONS OF ANY KIND, either express or implied. See the License for  
// thespecific language governing permissions and limitations under the       
// License. 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Keyfactor.Logging;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Exceptions;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;
using Keyfactor.Extensions.CAPlugin.HydrantId;
using Keyfactor.AnyGateway.Extensions;
using HawkNet;
using System.Globalization;

namespace Keyfactor.HydrantId.Client
{
    public sealed class HydrantIdClient
    {
        private static readonly ILogger Log = LogHandler.GetClassLogger < HydrantIdClient>();

        public HydrantIdClient(IAnyCAPluginConfigProvider config)
        {
            try
            {
                Log.MethodEntry();
                
                if (config.CAConnectionData.ContainsKey(HydrantIdCAPluginConfig.ConfigConstants.HydrantIdAuthId))
                {
                    ConfigProvider = config;
                    BaseUrl = ConfigProvider.CAConnectionData[HydrantIdCAPluginConfig.ConfigConstants.HydrantIdBaseUrl].ToString();
                    RequestManager = new RequestManager();
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Error Occured in HydrantIdClient.HydrantIdClient: {e.Message}");
                throw;
            }
        }

        private string BaseUrl { get; }
        private int PageSize { get; } = 100;
        private string ApiId { get; set; }
        private RequestManager RequestManager { get; }

        private IAnyCAPluginConfigProvider ConfigProvider { get; }

        public async Task<CertRequestResult> GetSubmitEnrollmentAsync(CertRequestBody registerRequest)
        {
            Log.MethodEntry();
            var apiEndpoint = "/api/v2/csr";
            var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);
            Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");

            var json = JsonConvert.SerializeObject(registerRequest);
            Log.LogTrace($"Register Request JSON: {json}");

            var traceWriter = new MemoryTraceWriter();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TraceWriter = traceWriter
            };

            using var resp = await restClient.PostAsync(apiEndpoint, new StringContent(json, Encoding.UTF8, "application/json"));
            var responseContent = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode == HttpStatusCode.InternalServerError)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorReturn>(responseContent, settings);
                Log.LogError($"Error Response JSON: {JsonConvert.SerializeObject(errorResponse)}");
                return new CertRequestResult { ErrorReturn = errorResponse };
            }

            var validResponse = JsonConvert.DeserializeObject<CertRequestStatus>(responseContent, settings);
            Log.LogTrace($"Valid Response JSON: {JsonConvert.SerializeObject(validResponse)}");
            return new CertRequestResult { RequestStatus = validResponse };
        }


        public async Task<CertRequestResult> GetSubmitRenewalAsync(string certificateId, RenewalRequest renewRequest)
        {
            Log.MethodEntry();
            var apiEndpoint = $"/api/v2/certificates/{certificateId}/renew";
            var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);
            Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");

            var json = JsonConvert.SerializeObject(renewRequest);
            Log.LogTrace($"Renew Request JSON: {json}");

            var traceWriter = new MemoryTraceWriter();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TraceWriter = traceWriter
            };

            using var resp = await restClient.PostAsync(apiEndpoint, new StringContent(json, Encoding.UTF8, "application/json"));
            var responseContent = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode == HttpStatusCode.InternalServerError)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorReturn>(responseContent, settings);
                Log.LogError($"Error Response JSON: {JsonConvert.SerializeObject(errorResponse)}");
                return new CertRequestResult { ErrorReturn = errorResponse };
            }

            var validResponse = JsonConvert.DeserializeObject<CertRequestStatus>(responseContent, settings);
            Log.LogTrace($"Valid Response JSON: {JsonConvert.SerializeObject(validResponse)}");
            return new CertRequestResult { RequestStatus = validResponse };
        }



        public async Task<List<Policy>> GetPolicyList()
        {
            Log.MethodEntry();
            var apiEndpoint = "/api/v2/policies";
            var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);
            Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");

            var traceWriter = new MemoryTraceWriter();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TraceWriter = traceWriter
            };

            using var resp = await restClient.GetAsync(apiEndpoint);
            var responseContent = await resp.Content.ReadAsStringAsync();
            var policies = JsonConvert.DeserializeObject<List<Policy>>(responseContent, settings);
            Log.LogDebug(traceWriter.ToString());

            return policies;
        }



        public async Task<Certificate> GetSubmitGetCertificateAsync(string certificateId)
        {
            Log.MethodEntry();

            var apiEndpoint = $"/api/v2/certificates/{certificateId}";
            Log.LogTrace($"API Url: {BaseUrl + apiEndpoint}");

            try
            {
                var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);
                using var response = await restClient.GetAsync(apiEndpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Certificate>(content);
            }
            catch (Exception e)
            {
                Log.LogError($"Error in HydrantIdClient.GetSubmitGetCertificateAsync: {e.Message}");
                throw;
            }
        }


        public async Task<Certificate> GetSubmitGetCertificateByCsrAsync(string requestTrackingId)
        {
            try
            {
                Log.MethodEntry();
                var apiEndpoint = $"/api/v2/csr/{requestTrackingId}/certificate";
                Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");
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
                Log.LogError($"Error Occured in HydrantIdClient.GetSubmitGetCertificateAsync: {e.Message}");
                throw;
            }
        }

        public async Task<CertificateStatus> GetSubmitRevokeCertificateAsync(string hydrantId, RevocationReasons revokeReason)
        {
            Log.MethodEntry();

            var apiEndpoint = $"/api/v2/certificates/{hydrantId}";
            var fullUrl = BaseUrl + apiEndpoint;

            Log.LogTrace($"API Url: {fullUrl}");

            var restClient = ConfigureRestClient("patch", fullUrl);
            var revokeRequest = RequestManager.GetRevokeRequest(revokeReason);
            Log.LogTrace($"Revoke Request JSON: {JsonConvert.SerializeObject(revokeRequest)}");

            try
            {
                using var response = await restClient.PatchAsync(new Uri(fullUrl), new StringContent(
                    JsonConvert.SerializeObject(revokeRequest), Encoding.UTF8, "application/json"));

                var json = await response.Content.ReadAsStringAsync();
                var revokeResponse = JsonConvert.DeserializeObject<CertificateStatus>(
                    json,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                Log.LogTrace($"Revoke Response JSON: {JsonConvert.SerializeObject(revokeResponse)}");
                return revokeResponse;
            }
            catch (Exception e)
            {
                Log.LogError($"Error in HydrantIdClient.GetSubmitRevokeCertificateAsync: {e.Message}");
                throw;
            }
        }


        public async Task GetSubmitCertificateListRequestAsync(BlockingCollection<ICertificatesResponseItem> bc,
            CancellationToken ct)
        {
            Log.MethodEntry();
            try
            {
                var itemsProcessed = 0;
                var pageCounter = 0;
                var isComplete = false;
                var retryCount = 0;
                do
                {
                    Log.LogTrace($"pageCounter: {pageCounter}  pageSize: {PageSize}");
                    var queryOrderRequest = RequestManager.GetCertificatesListRequest(pageCounter, PageSize);
                    Log.LogTrace($"queryOrderRequest JSON: {JsonConvert.SerializeObject(queryOrderRequest)}");
                    var batchItemsProcessed = 0;

                    var apiEndpoint = "/api/v2/certificates";
                    Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");
                    var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);

                    using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                        JsonConvert.SerializeObject(queryOrderRequest), Encoding.UTF8, "application/json"), ct))
                    {
                        if (!resp.IsSuccessStatusCode)
                        {
                            var responseMessage = resp.Content.ReadAsStringAsync().Result;
                            Log.LogError(
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

                        Log.LogTrace($"batchResponse JSON: {JsonConvert.SerializeObject(batchResponse)}");

                        if (batchResponse != null)
                        {
                            var batchCount = batchResponse.Items.Count;

                            Log.LogTrace($"Processing {batchCount} items in batch");
                            do
                            {
                                var r = batchResponse.Items[batchItemsProcessed];
                                if (bc.TryAdd(r, 10, ct))
                                {
                                    Log.LogTrace($"Added Template ID {r.Id} to Queue for processing");
                                    batchItemsProcessed++;
                                    itemsProcessed++;
                                    Log.LogTrace($"Processed {batchItemsProcessed} of {batchCount}");
                                    Log.LogTrace($"Total Items Processed: {itemsProcessed}");
                                }
                                else
                                {
                                    Log.LogTrace($"Adding {r} blocked. Retry");
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
                Log.LogWarning($"Synchronize method was cancelled. Message: {cancelEx.Message}");
                bc.CompleteAdding();
                Log.MethodExit();
                // ReSharper disable once PossibleIntendedRethrow
                throw;
            }
            catch (RetryCountExceededException retryEx)
            {
                Log.LogError($"Retries Failed: {retryEx.Message}");
                Log.MethodExit();
                bc.CompleteAdding();
                throw;
            }
            catch (HttpRequestException ex)
            {
                Log.LogError($"HttpRequest Failed: {ex.Message}");
                Log.MethodExit();
                bc.CompleteAdding();
                throw;
            }

            Log.MethodExit();
        }

        public async Task<bool> Ping()
        {
            Log.MethodEntry();

            var apiEndpoint = "/api/v2/policies"; // Lightweight, safe endpoint
            var fullUrl = BaseUrl + apiEndpoint;
            Log.LogTrace($"Ping API Url: {fullUrl}");

            try
            {
                var restClient = ConfigureRestClient("get", fullUrl);
                using var response = await restClient.GetAsync(apiEndpoint);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Log.LogError($"Ping failed. Status: {response.StatusCode}, Response: {content}");
                    return false;
                }

                Log.LogTrace("Ping successful.");
                return true;
            }
            catch (Exception e)
            {
                Log.LogError($"Error in HydrantIdClient.Ping: {e.Message}");
                return false;
            }
        }


        // ReSharper disable once InconsistentNaming
        private HttpClient ConfigureRestClient(string method, string url)
        {
            try
            {
                Log.MethodEntry();
                var bUrl = new Uri(BaseUrl);
                ApiId = ConfigProvider.CAConnectionData[HydrantIdCAPluginConfig.ConfigConstants.HydrantIdAuthId].ToString();

                var credentials = new HawkCredential
                {
                    Id = ConfigProvider.CAConnectionData[HydrantIdCAPluginConfig.ConfigConstants.HydrantIdAuthId].ToString(),
                    Key = ConfigProvider.CAConnectionData[HydrantIdCAPluginConfig.ConfigConstants.HydrantIdAuthKey].ToString(),
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
                var mac = Hawk.CalculateMac(bUrl.Host + ":" + bUrl.Port, method, new Uri(url), "",
                    ts.ToString(CultureInfo.InvariantCulture), nOnce, credentials, "header");
                var authorization =
                    $"id=\"{ApiId}\", ts=\"{ts}\", nonce=\"{nOnce}\", mac=\"{mac}\"";


                var clientHandler = new HttpClientHandler(); // Replaces WebRequestHandler in .NET 6

                var returnClient = new HttpClient(clientHandler, disposeHandler: true)
                {
                    BaseAddress = bUrl
                };

                returnClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                returnClient.DefaultRequestHeaders.Add("Authorization", "Hawk " + authorization);

                return returnClient;
            }
            catch (Exception e)
            {
                Log.LogError($"Error Occured in HydrantIdClient.ConfigureRestClient: {e.Message}");
                throw;
            }
        }

        private static byte[] ConvertHexStringToBytes(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Invalid length for hex string.");

            var bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return bytes;
        }
    }

}