using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Keyfactor.HydrantId.Api.Interfaces;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Model;
using RestSharp;

// ReSharper disable All

namespace Keyfactor.HydrantId.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CertificatesApi : ICertificatesApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificatesApi" /> class.
        /// </summary>
        /// <returns></returns>
        public CertificatesApi(String basePath)
        {
            Configuration = new Configuration {BasePath = basePath};

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificatesApi" /> class
        /// </summary>
        /// <returns></returns>
        public CertificatesApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificatesApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CertificatesApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                Configuration = Configuration.Default;
            else
                Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return Configuration.ApiClient.RestClient.BaseUrl?.ToString();
        }

        /// <summary>
        ///     Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        ///     Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }

                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>byte[]</returns>
        public byte[] CertificatesIdDerGet(Guid? id, bool? chain = null)
        {
            ApiResponse<byte[]> localVarResponse = CertificatesIdDerGetWithHttpInfo(id, chain);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>ApiResponse of byte[]</returns>
        public ApiResponse<byte[]> CertificatesIdDerGetWithHttpInfo(Guid? id, bool? chain = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdDerGet");

            var localVarPath = "/certificates/{id}/der";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/pkix-cert"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (chain != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "chain", chain)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdDerGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (byte[]) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(byte[])));
        }

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of byte[]</returns>
        public async Task<byte[]> CertificatesIdDerGetAsync(Guid? id, bool? chain = null)
        {
            ApiResponse<byte[]> localVarResponse = await CertificatesIdDerGetAsyncWithHttpInfo(id, chain);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        public async Task<ApiResponse<byte[]>> CertificatesIdDerGetAsyncWithHttpInfo(Guid? id, bool? chain = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdDerGet");

            var localVarPath = "/certificates/{id}/der";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/pkix-cert"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (chain != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "chain", chain)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdDerGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (byte[]) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(byte[])));
        }

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Certificate</returns>
        public Certificate CertificatesIdGet(Guid? id)
        {
            ApiResponse<Certificate> localVarResponse = CertificatesIdGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>ApiResponse of Certificate</returns>
        public ApiResponse<Certificate> CertificatesIdGetWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdGet");

            var localVarPath = "/certificates/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Certificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Certificate) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(Certificate)));
        }

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of Certificate</returns>
        public async Task<Certificate> CertificatesIdGetAsync(Guid? id)
        {
            ApiResponse<Certificate> localVarResponse = await CertificatesIdGetAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of ApiResponse (Certificate)</returns>
        public async Task<ApiResponse<Certificate>> CertificatesIdGetAsyncWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdGet");

            var localVarPath = "/certificates/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Certificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Certificate) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(Certificate)));
        }

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>CertificateStatus</returns>
        public CertificateStatus CertificatesIdPatch(RevokeCertificateReason body, string id)
        {
            ApiResponse<CertificateStatus> localVarResponse = CertificatesIdPatchWithHttpInfo(body, id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>ApiResponse of CertificateStatus</returns>
        public ApiResponse<CertificateStatus> CertificatesIdPatchWithHttpInfo(RevokeCertificateReason body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling CertificatesApi->CertificatesIdPatch");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdPatch");

            var localVarPath = "/certificates/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
                "application/json"
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdPatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificateStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificateStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificateStatus)));
        }

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>Task of CertificateStatus</returns>
        public async Task<CertificateStatus> CertificatesIdPatchAsync(RevokeCertificateReason body, string id)
        {
            ApiResponse<CertificateStatus> localVarResponse = await CertificatesIdPatchAsyncWithHttpInfo(body, id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>Task of ApiResponse (CertificateStatus)</returns>
        public async Task<ApiResponse<CertificateStatus>> CertificatesIdPatchAsyncWithHttpInfo(
            RevokeCertificateReason body, string id)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling CertificatesApi->CertificatesIdPatch");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdPatch");

            var localVarPath = "/certificates/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
                "application/json"
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdPatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificateStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificateStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificateStatus)));
        }

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>byte[]</returns>
        public byte[] CertificatesIdPemGet(Guid? id, bool? chain = null)
        {
            ApiResponse<byte[]> localVarResponse = CertificatesIdPemGetWithHttpInfo(id, chain);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>ApiResponse of byte[]</returns>
        public ApiResponse<byte[]> CertificatesIdPemGetWithHttpInfo(Guid? id, bool? chain = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdPemGet");

            var localVarPath = "/certificates/{id}/pem";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/x-pem-file"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (chain != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "chain", chain)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            Exception exception = ExceptionFactory?.Invoke("CertificatesIdPemGet", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (byte[]) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(byte[])));
        }

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of byte[]</returns>
        public async Task<byte[]> CertificatesIdPemGetAsync(Guid? id, bool? chain = null)
        {
            ApiResponse<byte[]> localVarResponse = await CertificatesIdPemGetAsyncWithHttpInfo(id, chain);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        public async Task<ApiResponse<byte[]>> CertificatesIdPemGetAsyncWithHttpInfo(Guid? id, bool? chain = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdPemGet");

            var localVarPath = "/certificates/{id}/pem";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/x-pem-file"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (chain != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "chain", chain)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdPemGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (byte[]) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(byte[])));
        }

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>CertificateStatus</returns>
        public CertificateStatus CertificatesIdStatusGet(string id)
        {
            ApiResponse<CertificateStatus> localVarResponse = CertificatesIdStatusGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>ApiResponse of CertificateStatus</returns>
        public ApiResponse<CertificateStatus> CertificatesIdStatusGetWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdStatusGet");

            var localVarPath = "/certificates/{id}/status";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            Exception exception = ExceptionFactory?.Invoke("CertificatesIdStatusGet", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<CertificateStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificateStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificateStatus)));
        }

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of CertificateStatus</returns>
        public async Task<CertificateStatus> CertificatesIdStatusGetAsync(string id)
        {
            ApiResponse<CertificateStatus> localVarResponse = await CertificatesIdStatusGetAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of ApiResponse (CertificateStatus)</returns>
        public async Task<ApiResponse<CertificateStatus>> CertificatesIdStatusGetAsyncWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificatesApi->CertificatesIdStatusGet");

            var localVarPath = "/certificates/{id}/status";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesIdStatusGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificateStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificateStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificateStatus)));
        }

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>GetCertificatesResponse</returns>
        public CertificatesResponse CertificatesPost(CertificatesPayload body = null)
        {
            ApiResponse<CertificatesResponse> localVarResponse = CertificatesPostWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>ApiResponse of GetCertificatesResponse</returns>
        public ApiResponse<CertificatesResponse> CertificatesPostWithHttpInfo(CertificatesPayload body = null)
        {
            var localVarPath = "/certificates";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
                "application/json"
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificatesResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificatesResponse) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificatesResponse)));
        }

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>Task of GetCertificatesResponse</returns>
        public async Task<CertificatesResponse> CertificatesPostAsync(CertificatesPayload body = null)
        {
            ApiResponse<CertificatesResponse> localVarResponse = await CertificatesPostAsyncWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>Task of ApiResponse (GetCertificatesResponse)</returns>
        public async Task<ApiResponse<CertificatesResponse>> CertificatesPostAsyncWithHttpInfo(
            CertificatesPayload body = null)
        {
            var localVarPath = "/certificates";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
                "application/json"
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificatesResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificatesResponse) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificatesResponse)));
        }

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>CertificateStatus</returns>
        public CertificateStatus CertificatesSerialNumberPatch(RevokeCertificateReasonIssuerDn body,
            string serialNumber)
        {
            ApiResponse<CertificateStatus> localVarResponse =
                CertificatesSerialNumberPatchWithHttpInfo(body, serialNumber);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>ApiResponse of CertificateStatus</returns>
        public ApiResponse<CertificateStatus> CertificatesSerialNumberPatchWithHttpInfo(
            RevokeCertificateReasonIssuerDn body, string serialNumber)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling CertificatesApi->CertificatesSerialNumberPatch");
            // verify the required parameter 'serialNumber' is set
            if (serialNumber == null)
                throw new ApiException(400,
                    "Missing required parameter 'serialNumber' when calling CertificatesApi->CertificatesSerialNumberPatch");

            var localVarPath = "/certificates/{serialNumber}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
                "application/json"
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("serialNumber",
                Configuration.ApiClient.GetParameterToString(serialNumber)); // path parameter
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesSerialNumberPatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificateStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificateStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificateStatus)));
        }

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>Task of CertificateStatus</returns>
        public async Task<CertificateStatus> CertificatesSerialNumberPatchAsync(RevokeCertificateReasonIssuerDn body,
            string serialNumber)
        {
            ApiResponse<CertificateStatus> localVarResponse =
                await CertificatesSerialNumberPatchAsyncWithHttpInfo(body, serialNumber);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>Task of ApiResponse (CertificateStatus)</returns>
        public async Task<ApiResponse<CertificateStatus>> CertificatesSerialNumberPatchAsyncWithHttpInfo(
            RevokeCertificateReasonIssuerDn body, string serialNumber)
        {
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400,
                    "Missing required parameter 'body' when calling CertificatesApi->CertificatesSerialNumberPatch");
            // verify the required parameter 'serialNumber' is set
            if (serialNumber == null)
                throw new ApiException(400,
                    "Missing required parameter 'serialNumber' when calling CertificatesApi->CertificatesSerialNumberPatch");

            var localVarPath = "/certificates/{serialNumber}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[]
            {
                "application/json"
            };
            String localVarHttpContentType =
                Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[]
            {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("serialNumber",
                Configuration.ApiClient.GetParameterToString(serialNumber)); // path parameter
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CertificatesSerialNumberPatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertificateStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertificateStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertificateStatus)));
        }

        /// <summary>
        ///     Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete(
            "SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        ///     Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(Configuration.DefaultHeader);
        }

        /// <summary>
        ///     Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            Configuration.GetAddDefaultHeader(key, value);
        }
    }
}