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
    public class PoliciesApi : IPoliciesApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PoliciesApi" /> class.
        /// </summary>
        /// <returns></returns>
        public PoliciesApi(String basePath)
        {
            Configuration = new Configuration {BasePath = basePath};

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PoliciesApi" /> class
        /// </summary>
        /// <returns></returns>
        public PoliciesApi()
        {
            Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PoliciesApi" /> class
        ///     using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public PoliciesApi(Configuration configuration = null)
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
        ///     Get all policies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>List&lt;Policy&gt;</returns>
        public List<Policy> PoliciesGet(string imported = null)
        {
            ApiResponse<List<Policy>> localVarResponse = PoliciesGetWithHttpInfo(imported);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>ApiResponse of List&lt;Policy&gt;</returns>
        public ApiResponse<List<Policy>> PoliciesGetWithHttpInfo(string imported = null)
        {
            var localVarPath = "/policies";
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

            if (imported != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "imported", imported)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.GetCallApi(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PoliciesGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Policy>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<Policy>) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(List<Policy>)));
        }

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>Task of List&lt;Policy&gt;</returns>
        public async Task<List<Policy>> PoliciesGetAsync(string imported = null)
        {
            ApiResponse<List<Policy>> localVarResponse = await PoliciesGetAsyncWithHttpInfo(imported);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>Task of ApiResponse (List&lt;Policy&gt;)</returns>
        public async Task<ApiResponse<List<Policy>>> PoliciesGetAsyncWithHttpInfo(string imported = null)
        {
            var localVarPath = "/policies";
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

            if (imported != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "imported", imported)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.GetCallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, null, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PoliciesGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Policy>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (List<Policy>) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(List<Policy>)));
        }

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>Policy</returns>
        public Policy PoliciesIdGet(Guid? id)
        {
            ApiResponse<Policy> localVarResponse = PoliciesIdGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>ApiResponse of Policy</returns>
        public ApiResponse<Policy> PoliciesIdGetWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling PoliciesApi->PoliciesIdGet");

            var localVarPath = "/policies/{id}";
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

            Exception exception = ExceptionFactory?.Invoke("PoliciesIdGet", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<Policy>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Policy) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(Policy)));
        }

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>Task of Policy</returns>
        public async Task<Policy> PoliciesIdGetAsync(Guid? id)
        {
            ApiResponse<Policy> localVarResponse = await PoliciesIdGetAsyncWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        public async Task<ApiResponse<Policy>> PoliciesIdGetAsyncWithHttpInfo(Guid? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling PoliciesApi->PoliciesIdGet");

            var localVarPath = "/policies/{id}";
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

            Exception exception = ExceptionFactory?.Invoke("PoliciesIdGet", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<Policy>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Policy) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(Policy)));
        }

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>Policy</returns>
        public Policy PoliciesIdPut(string id, Policy body = null, string commit = null)
        {
            ApiResponse<Policy> localVarResponse = PoliciesIdPutWithHttpInfo(id, body, commit);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>ApiResponse of Policy</returns>
        public ApiResponse<Policy> PoliciesIdPutWithHttpInfo(string id, Policy body = null, string commit = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling PoliciesApi->PoliciesIdPut");

            var localVarPath = "/policies/{id}";
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
            if (commit != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "commit", commit)); // query parameter
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
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PoliciesIdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Policy>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Policy) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(Policy)));
        }

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>Task of Policy</returns>
        public async Task<Policy> PoliciesIdPutAsync(string id, Policy body = null, string commit = null)
        {
            ApiResponse<Policy> localVarResponse = await PoliciesIdPutAsyncWithHttpInfo(id, body, commit);
            return localVarResponse.Data;
        }

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        public async Task<ApiResponse<Policy>> PoliciesIdPutAsyncWithHttpInfo(string id, Policy body = null,
            string commit = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling PoliciesApi->PoliciesIdPut");

            var localVarPath = "/policies/{id}";
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
            if (commit != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.GetParameterToKeyValuePairs("", "commit", commit)); // query parameter
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
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams,
                localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PoliciesIdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Policy>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Policy) Configuration.ApiClient.GetDeserialize(localVarResponse, typeof(Policy)));
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