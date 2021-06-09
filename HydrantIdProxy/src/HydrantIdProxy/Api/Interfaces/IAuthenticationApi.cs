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
    public interface IAuthenticationApi : IApiAccessor
    {
        #region Synchronous Operations

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;HawkCredential&gt;</returns>
        List<HawkCredential> HawkGet();

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;HawkCredential&gt;</returns>
        ApiResponse<List<HawkCredential>> HawkGetWithHttpInfo();

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>HawkCredentialDeleteResults</returns>
        HawkCredentialDeleteResults HawkIdDelete(string id);

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>ApiResponse of HawkCredentialDeleteResults</returns>
        ApiResponse<HawkCredentialDeleteResults> HawkIdDeleteWithHttpInfo(string id);

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>HawkCredential</returns>
        HawkCredential HawkIdGet(string id);

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        ApiResponse<HawkCredential> HawkIdGetWithHttpInfo(string id);

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>HawkCredential</returns>
        HawkCredential HawkIdPatch(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        ApiResponse<HawkCredential> HawkIdPatchWithHttpInfo(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>HawkCredential</returns>
        HawkCredential HawkIdPut(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        ApiResponse<HawkCredential> HawkIdPutWithHttpInfo(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>HawkCredential</returns>
        HawkCredential HawkPost(HawkCredentialComments body = null);

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>ApiResponse of HawkCredential</returns>
        ApiResponse<HawkCredential> HawkPostWithHttpInfo(HawkCredentialComments body = null);

        #endregion Synchronous Operations

        #region Asynchronous Operations

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List&lt;HawkCredential&gt;</returns>
        Task<List<HawkCredential>> HawkGetAsync();

        /// <summary>
        ///     Get all HAWK Credentials associated with the current user user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (List&lt;HawkCredential&gt;)</returns>
        Task<ApiResponse<List<HawkCredential>>> HawkGetAsyncWithHttpInfo();

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>Task of HawkCredentialDeleteResults</returns>
        Task<HawkCredentialDeleteResults> HawkIdDeleteAsync(string id);

        /// <summary>
        ///     Delete a specific HAWK credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to delete</param>
        /// <returns>Task of ApiResponse (HawkCredentialDeleteResults)</returns>
        Task<ApiResponse<HawkCredentialDeleteResults>> HawkIdDeleteAsyncWithHttpInfo(string id);

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>Task of HawkCredential</returns>
        Task<HawkCredential> HawkIdGetAsync(string id);

        /// <summary>
        ///     Get a specific HAWK Credential
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to retrieve</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        Task<ApiResponse<HawkCredential>> HawkIdGetAsyncWithHttpInfo(string id);

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of HawkCredential</returns>
        Task<HawkCredential> HawkIdPatchAsync(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Add/update a comment for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update comments</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        Task<ApiResponse<HawkCredential>> HawkIdPatchAsyncWithHttpInfo(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of HawkCredential</returns>
        Task<HawkCredential> HawkIdPutAsync(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Create a new secret for a specific HAWK credential.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Identifier of HAWK credential to update</param>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        Task<ApiResponse<HawkCredential>> HawkIdPutAsyncWithHttpInfo(string id, HawkCredentialComment body = null);

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of HawkCredential</returns>
        Task<HawkCredential> HawkPostAsync(HawkCredentialComments body = null);

        /// <summary>
        ///     Create a new HAWK Credential for the current user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Optional comment (max 255 characters) (optional)</param>
        /// <returns>Task of ApiResponse (HawkCredential)</returns>
        Task<ApiResponse<HawkCredential>> HawkPostAsyncWithHttpInfo(HawkCredentialComments body = null);

        #endregion Asynchronous Operations
    }
}