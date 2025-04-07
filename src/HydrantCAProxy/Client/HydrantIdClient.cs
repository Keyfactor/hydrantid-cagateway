// Copyright 2025 Keyfactor                                                   
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
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CAProxy.AnyGateway.Interfaces;
using Keyfactor.Logging;
using HawkNet;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Exceptions;
using Keyfactor.HydrantId.Extensions;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Keyfactor.AnyGateway.Google;
using Microsoft.Extensions.Logging;

namespace Keyfactor.HydrantId.Client
{
    public sealed class HydrantIdClient
    {
        private static readonly ILogger Log = LogHandler.GetClassLogger < HydrantIdClient>();

        public HydrantIdClient(ICAConnectorConfigProvider config)
        {
            try
            {
                Log.MethodEntry();
                if (config.CAConnectionData.ContainsKey(Constants.HydrantIdAuthId))
                {
                    ConfigProvider = config;
                    BaseUrl = ConfigProvider.CAConnectionData[Constants.HydrantIdBaseUrl].ToString();
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

        private ICAConnectorConfigProvider ConfigProvider { get; }

        public async Task<CertRequestResult> GetSubmitEnrollmentAsync(
            CertRequestBody registerRequest)
        {
            Log.MethodEntry();
            var apiEndpoint = "/api/v2/csr";
            Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");
            var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);
            var traceWriter = new MemoryTraceWriter();

            using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                JsonConvert.SerializeObject(registerRequest), Encoding.UTF8, "application/json")))
            {
                try
                {
                    Log.LogTrace($"Register Request JSON: {JsonConvert.SerializeObject(registerRequest)}");
                    var settings = new JsonSerializerSettings
                        {NullValueHandling = NullValueHandling.Ignore, TraceWriter = traceWriter};
                    var _ = await resp.Content.ReadAsStringAsync();

                    if (resp.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var errorResponse =
                            JsonConvert.DeserializeObject<ErrorReturn>(await resp.Content.ReadAsStringAsync(),
                                settings);
                        Log.LogError($"Error Response JSON: {JsonConvert.SerializeObject(errorResponse)}");
                        var responseReturn = new CertRequestResult {ErrorReturn = errorResponse, RequestStatus = null};
                        return responseReturn;
                    }

                    var validResponse =
                        JsonConvert.DeserializeObject<CertRequestStatus>(await resp.Content.ReadAsStringAsync(),
                            settings);
                    Log.LogError($"validResponse Response JSON: {JsonConvert.SerializeObject(validResponse)}");
                    var validReturn = new CertRequestResult {ErrorReturn = null, RequestStatus = validResponse};
                    return validReturn;
                }
                catch (Exception e)
                {
                    Log.LogError($"Error Occured in HydrantIdClient.GetSubmitEnrollmentAsync: {e.Message}");
                    throw;
                }
            }
        }


        public async Task<CertRequestResult> GetSubmitRenewalAsync(string certificateId,
            RenewalRequest renewRequest)
        {
            try
            {
                Log.MethodEntry();
                var apiEndpoint = $"/api/v2/certificates/{certificateId}/renew";
                var restClient = ConfigureRestClient("post", BaseUrl + apiEndpoint);
                Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");
                var traceWriter = new MemoryTraceWriter();

                using (var resp = await restClient.PostAsync(apiEndpoint, new StringContent(
                    JsonConvert.SerializeObject(renewRequest), Encoding.UTF8, "application/json")))
                {
                    Log.LogTrace($"Renew Request: {JsonConvert.SerializeObject(renewRequest)}");
                    var settings = new JsonSerializerSettings
                        { NullValueHandling = NullValueHandling.Ignore, TraceWriter = traceWriter };
                    var _ = await resp.Content.ReadAsStringAsync();

                    if (resp.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var errorResponse =
                            JsonConvert.DeserializeObject<ErrorReturn>(await resp.Content.ReadAsStringAsync(),
                                settings);
                        Log.LogError($"Error Response JSON: {JsonConvert.SerializeObject(errorResponse)}");
                        var responseReturn = new CertRequestResult { ErrorReturn = errorResponse, RequestStatus = null };
                        return responseReturn;
                    }

                    var validResponse =
                        JsonConvert.DeserializeObject<CertRequestStatus>(await resp.Content.ReadAsStringAsync(),
                            settings);
                    Log.LogError($"validResponse Response JSON: {JsonConvert.SerializeObject(validResponse)}");
                    var validReturn = new CertRequestResult { ErrorReturn = null, RequestStatus = validResponse };
                    return validReturn;
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Error Occured in HydrantIdClient.GetSubmitRenewalAsync: {e.Message}");
                throw;
            }
        }


        public async Task<List<Policy>> GetPolicyList()
        {
            try
            {
                Log.MethodEntry();
                var apiEndpoint = "/api/v2/policies";
                Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");
                var restClient = ConfigureRestClient("get", BaseUrl + apiEndpoint);

                var traceWriter = new MemoryTraceWriter();

                using (var resp = await restClient.GetAsync(apiEndpoint))
                {
                    var settings = new JsonSerializerSettings
                        {NullValueHandling = NullValueHandling.Ignore, TraceWriter = traceWriter};
                    var policiesResponse =
                        JsonConvert.DeserializeObject<List<Policy>>(await resp.Content.ReadAsStringAsync(),
                            settings);
                    Log.LogDebug(traceWriter.ToString());
                    return policiesResponse;
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Error Occured in HydrantIdClient.GetPolicyList: {e.Message}");
                throw;
            }
        }


        public async Task<Certificate> GetSubmitGetCertificateAsync(string certificateId)
        {
            try
            {
                Log.MethodEntry();
                var apiEndpoint = $"/api/v2/certificates/{certificateId}";
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

        public async Task<CertificateStatus> GetSubmitRevokeCertificateAsync(string hydrantId,
            RevocationReasons revokeReason)
        {
            try
            {
                Log.MethodEntry();
                var apiEndpoint = $"/api/v2/certificates/{hydrantId}";
                Log.LogTrace($"API Url {BaseUrl + apiEndpoint}");
                var restClient = ConfigureRestClient("patch", BaseUrl + apiEndpoint);
                var revokeRequest = RequestManager.GetRevokeRequest(revokeReason);
                Log.LogTrace($"Revoke Request JSON: {JsonConvert.SerializeObject(revokeRequest)}");
                using (var resp = await restClient.PatchAsync(new Uri(BaseUrl + apiEndpoint), new StringContent(
                    JsonConvert.SerializeObject(revokeRequest), Encoding.UTF8, "application/json")))
                {
                    var jsonSerializerSettings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
                    var getRevokeResponse =
                        JsonConvert.DeserializeObject<CertificateStatus>(await resp.Content.ReadAsStringAsync(),
                            jsonSerializerSettings);
                    Log.LogTrace($"Revoke Response JSON: {JsonConvert.SerializeObject(getRevokeResponse)}");
                    return getRevokeResponse;
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Error Occured in HydrantIdClient.GetSubmitRevokeCertificateAsync: {e.Message}");
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
                throw cancelEx;
            }
            catch (RetryCountExceededException retryEx)
            {
                Log.LogError($"Retries Failed: {retryEx.Message}");
                Log.MethodExit();
                bc.CompleteAdding();
                throw retryEx;
            }
            catch (HttpRequestException ex)
            {
                Log.LogError($"HttpRequest Failed: {ex.Message}");
                Log.MethodExit();
                bc.CompleteAdding();
                throw ex;
            }

            Log.MethodExit();
        }

        // ReSharper disable once InconsistentNaming
        private HttpClient ConfigureRestClient(string method, string url)
        {
            try
            {
                Log.MethodEntry();
                var bUrl = new Uri(BaseUrl);
                ApiId = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthId].ToString();

                var credentials = new HawkCredential
                {
                    Id = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthId].ToString(),
                    Key = ConfigProvider.CAConnectionData[Constants.HydrantIdAuthKey].ToString(),
                    Algorithm = "sha256"
                };

                Log.LogTrace($"HawkCredential JSON: {JsonConvert.SerializeObject(credentials)}");

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

                Log.LogTrace($"Authorization: {authorization}");

                var clientHandler = new WebRequestHandler();
                var returnClient = new HttpClient(clientHandler, true) {BaseAddress = bUrl};
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
    }
}