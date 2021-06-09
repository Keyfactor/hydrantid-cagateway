using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Keyfactor.HydrantId.Api.Interfaces;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Model;
using RestSharp;

// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CertificateRequestsApi : ICertificateRequestsApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificateRequestsApi" /> class.
        /// </summary>
        /// <returns></returns>
        public CertificateRequestsApi(string basePath)
        {
            Configuration = new Configuration {BasePath = basePath};

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificateRequestsApi" /> class
        /// </summary>
        /// <returns></returns>
        public CertificateRequestsApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificateRequestsApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CertificateRequestsApi(Configuration configuration = null)
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
        public string GetBasePath()
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
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>CertRequest</returns>
        public CertRequest CsrIdGet(Guid? id)
        {
            var localVarResponse = CsrIdGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>ApiResponse of CertRequest</returns>
        public ApiResponse<CertRequest> CsrIdGetWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificateRequestsApi->CsrIdGet");

            var localVarPath = "/csr/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CsrIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertRequest>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertRequest) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(CertRequest)));
        }

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of CertRequest</returns>
        public async Task<CertRequest> CsrIdGetAsync(Guid? id)
        {
            var localVarResponse = await CsrIdGetAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of ApiResponse (CertRequest)</returns>
        public async Task<ApiResponse<CertRequest>> CsrIdGetAsyncWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificateRequestsApi->CsrIdGet");

            var localVarPath = "/csr/{id}";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CsrIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertRequest>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertRequest) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(CertRequest)));
        }

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>CertRequestStatus</returns>
        public CertRequestStatus CsrIdStatusGet(Guid? id)
        {
            var localVarResponse = CsrIdStatusGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>ApiResponse of CertRequestStatus</returns>
        public ApiResponse<CertRequestStatus> CsrIdStatusGetWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificateRequestsApi->CsrIdStatusGet");

            var localVarPath = "/csr/{id}/status";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CsrIdStatusGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertRequestStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertRequestStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertRequestStatus)));
        }

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of CertRequestStatus</returns>
        public async Task<CertRequestStatus> CsrIdStatusGetAsync(Guid? id)
        {
            var localVarResponse = await CsrIdStatusGetAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of ApiResponse (CertRequestStatus)</returns>
        public async Task<ApiResponse<CertRequestStatus>> CsrIdStatusGetAsyncWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling CertificateRequestsApi->CsrIdStatusGet");

            var localVarPath = "/csr/{id}/status";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
            };
            var localVarHttpContentType = Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("CsrIdStatusGet", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<CertRequestStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertRequestStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertRequestStatus)));
        }

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>CertRequestStatus</returns>
        public CertRequestStatus CsrPost(CertRequestBody body = null)
        {
            var localVarResponse = CsrPostWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of CertRequestStatus</returns>
        public ApiResponse<CertRequestStatus> CsrPostWithHttpInfo(CertRequestBody body = null)
        {
            var localVarPath = "/csr";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
                "application/json"
            };
            var localVarHttpContentType = Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CsrPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertRequestStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertRequestStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertRequestStatus)));
        }

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of CertRequestStatus</returns>
        public async Task<CertRequestStatus> CsrPostAsync(CertRequestBody body = null)
        {
            var localVarResponse = await CsrPostAsyncWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (CertRequestStatus)</returns>
        public async Task<ApiResponse<CertRequestStatus>> CsrPostAsyncWithHttpInfo(CertRequestBody body = null)
        {
            var localVarPath = "/csr";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<string, string>();
            var localVarFileParams = new Dictionary<string, FileParameter>();
            object localVarPostBody;

            // to determine the Content-Type header
            string[] localVarHttpContentTypes =
            {
                "application/json"
            };
            var localVarHttpContentType = Configuration.ApiClient.GetSelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            string[] localVarHttpHeaderAccepts =
            {
                "application/json"
            };
            var localVarHttpHeaderAccept = Configuration.ApiClient.GetSelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("CsrPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CertRequestStatus>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (CertRequestStatus) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(CertRequestStatus)));
        }

        /// <summary>
        ///     Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete(
            "SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(string basePath)
        {
            // do nothing
        }

        /// <summary>
        ///     Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<string, string> DefaultHeader()
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