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
    public class AuthenticationApi : IAuthenticationApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationApi" /> class.
        /// </summary>
        /// <returns></returns>
        public AuthenticationApi(string basePath)
        {
            Configuration = new Configuration {BasePath = basePath};

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationApi" /> class
        /// </summary>
        /// <returns></returns>
        public AuthenticationApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthenticationApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AuthenticationApi(Configuration configuration = null)
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
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;HawkCredential&gt;</returns>
        public List<HawkCredential> HawkGet()
        {
            var localVarResponse = HawkGetWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;HawkCredential&gt;</returns>
        public ApiResponse<List<HawkCredential>> HawkGetWithHttpInfo()
        {
            var localVarPath = "/hawk";
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


            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<HawkCredential>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<HawkCredential>) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(List<HawkCredential>)));
        }

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;HawkCredential&gt;</returns>
        public async Task<List<HawkCredential>> HawkGetAsync()
        {
            var localVarResponse = await HawkGetAsyncWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;HawkCredential&gt;)</returns>
        public async Task<ApiResponse<List<HawkCredential>>> HawkGetAsyncWithHttpInfo()
        {
            var localVarPath = "/hawk";
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


            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<HawkCredential>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<HawkCredential>) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(List<HawkCredential>)));
        }

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>HawkCredentialDeleteResults</returns>
        public HawkCredentialDeleteResults HawkIdDelete(string id)
        {
            var localVarResponse = HawkIdDeleteWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>ApiResponse of HawkCredentialDeleteResults</returns>
        public ApiResponse<HawkCredentialDeleteResults> HawkIdDeleteWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdDelete");

            var localVarPath = "/hawk/{id}";
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
                Method.DELETE, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkIdDelete", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredentialDeleteResults>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredentialDeleteResults) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(HawkCredentialDeleteResults)));
        }

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>Task of HawkCredentialDeleteResults</returns>
        public async Task<HawkCredentialDeleteResults> HawkIdDeleteAsync(string id)
        {
            var localVarResponse = await HawkIdDeleteAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>Task of ApiResponse (HawkCredentialDeleteResults)</returns>
        public async Task<ApiResponse<HawkCredentialDeleteResults>> HawkIdDeleteAsyncWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdDelete");

            var localVarPath = "/hawk/{id}";
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
                Method.DELETE, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkIdDelete", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredentialDeleteResults>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredentialDeleteResults) Configuration.ApiClient.GetDeserialize(localVarResponse,
                    typeof(HawkCredentialDeleteResults)));
        }

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>HawkCredential</returns>
        public HawkCredential HawkIdGet(string id)
        {
            var localVarResponse = HawkIdGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        public ApiResponse<HawkCredential> HawkIdGetWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdGet");

            var localVarPath = "/hawk/{id}";
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

            var exception = ExceptionFactory?.Invoke("HawkIdGet", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>Task of HawkCredential</returns>
        public async Task<HawkCredential> HawkIdGetAsync(string id)
        {
            var localVarResponse = await HawkIdGetAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        public async Task<ApiResponse<HawkCredential>> HawkIdGetAsyncWithHttpInfo(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdGet");

            var localVarPath = "/hawk/{id}";
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
                var exception = ExceptionFactory("HawkIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>HawkCredential</returns>
        public HawkCredential HawkIdPatch(string id, HawkCredentialComment body = null)
        {
            var localVarResponse = HawkIdPatchWithHttpInfo(id, body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        public ApiResponse<HawkCredential> HawkIdPatchWithHttpInfo(string id, HawkCredentialComment body = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdPatch");

            var localVarPath = "/hawk/{id}";
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

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("HawkIdPatch", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of HawkCredential</returns>
        public async Task<HawkCredential> HawkIdPatchAsync(string id, HawkCredentialComment body = null)
        {
            var localVarResponse = await HawkIdPatchAsyncWithHttpInfo(id, body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        public async Task<ApiResponse<HawkCredential>> HawkIdPatchAsyncWithHttpInfo(string id,
            HawkCredentialComment body = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdPatch");

            var localVarPath = "/hawk/{id}";
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

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkIdPatch", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>HawkCredential</returns>
        public HawkCredential HawkIdPut(string id, HawkCredentialComment body = null)
        {
            var localVarResponse = HawkIdPutWithHttpInfo(id, body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        public ApiResponse<HawkCredential> HawkIdPutWithHttpInfo(string id, HawkCredentialComment body = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdPut");

            var localVarPath = "/hawk/{id}";
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

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkIdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of HawkCredential</returns>
        public async Task<HawkCredential> HawkIdPutAsync(string id, HawkCredentialComment body = null)
        {
            var localVarResponse = await HawkIdPutAsyncWithHttpInfo(id, body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        public async Task<ApiResponse<HawkCredential>> HawkIdPutAsyncWithHttpInfo(string id,
            HawkCredentialComment body = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400,
                    "Missing required parameter 'id' when calling AuthenticationApi->HawkIdPut");

            var localVarPath = "/hawk/{id}";
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

            localVarPathParams.Add("id", Configuration.ApiClient.GetParameterToString(id)); // path parameter
            if (body != null && body.GetType() != typeof(byte[]))
                localVarPostBody = Configuration.ApiClient.GetSerialize(body); // http body (model) parameter
            else
                localVarPostBody = body; // byte array

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                var exception = ExceptionFactory("HawkIdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>HawkCredential</returns>
        public HawkCredential HawkPost(HawkCredentialComments body = null)
        {
            var localVarResponse = HawkPostWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        public ApiResponse<HawkCredential> HawkPostWithHttpInfo(HawkCredentialComments body = null)
        {
            var localVarPath = "/hawk";
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
                var exception = ExceptionFactory("HawkPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
        }

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of HawkCredential</returns>
        public async Task<HawkCredential> HawkPostAsync(HawkCredentialComments body = null)
        {
            var localVarResponse = await HawkPostAsyncWithHttpInfo(body);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        public async Task<ApiResponse<HawkCredential>> HawkPostAsyncWithHttpInfo(HawkCredentialComments body = null)
        {
            var localVarPath = "/hawk";
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
                var exception = ExceptionFactory("HawkPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<HawkCredential>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (HawkCredential) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(HawkCredential)));
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