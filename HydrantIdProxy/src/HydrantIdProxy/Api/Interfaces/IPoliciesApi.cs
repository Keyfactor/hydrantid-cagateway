using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Client.Interfaces;
using Keyfactor.HydrantId.Model;

namespace Keyfactor.HydrantId.Api.Interfaces
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPoliciesApi : IApiAccessor
    {
        #region Synchronous Operations

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>List&lt;Policy&gt;</returns>
        List<Policy> PoliciesGet(string imported = null);

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>ApiResponse of List&lt;Policy&gt;</returns>
        ApiResponse<List<Policy>> PoliciesGetWithHttpInfo(string imported = null);

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>Policy</returns>
        Policy PoliciesIdGet(Guid? id);

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>ApiResponse of Policy</returns>
        ApiResponse<Policy> PoliciesIdGetWithHttpInfo(Guid? id);

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>Policy</returns>
        Policy PoliciesIdPut(string id, Policy body = null, string commit = null);

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>ApiResponse of Policy</returns>
        ApiResponse<Policy> PoliciesIdPutWithHttpInfo(string id, Policy body = null, string commit = null);

        #endregion Synchronous Operations

        #region Asynchronous Operations

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>Task of List&lt;Policy&gt;</returns>
        Task<List<Policy>> PoliciesGetAsync(string imported = null);

        /// <summary>
        ///     Get all policies
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="imported">
        ///     Load imported policies (type &#x3D; IMPORTED) - true: include imported, false: exclude imported,
        ///     only: only imported (optional)
        /// </param>
        /// <returns>Task of ApiResponse (List&lt;Policy&gt;)</returns>
        Task<ApiResponse<List<Policy>>> PoliciesGetAsyncWithHttpInfo(string imported = null);

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>Task of Policy</returns>
        Task<Policy> PoliciesIdGetAsync(Guid? id);

        /// <summary>
        ///     Get a specific policy
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        Task<ApiResponse<Policy>> PoliciesIdGetAsyncWithHttpInfo(Guid? id);

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>Task of Policy</returns>
        Task<Policy> PoliciesIdPutAsync(string id, Policy body = null, string commit = null);

        /// <summary>
        ///     Update a policy with preview changes
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Policy id</param>
        /// <param name="body"> (optional)</param>
        /// <param name="commit">if commit&#x3D;true then the policy will be updated (optional)</param>
        /// <returns>Task of ApiResponse (Policy)</returns>
        Task<ApiResponse<Policy>> PoliciesIdPutAsyncWithHttpInfo(string id, Policy body = null, string commit = null);

        #endregion Asynchronous Operations
    }
}