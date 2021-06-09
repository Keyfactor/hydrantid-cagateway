using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Client.Interfaces;
using Keyfactor.HydrantId.Model;

namespace Keyfactor.HydrantId.Api.Interfaces
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public interface ICertificateRequestsApi : IApiAccessor
    {
        #region Synchronous Operations

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>CertRequest</returns>
        CertRequest CsrIdGet(Guid? id);

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>ApiResponse of CertRequest</returns>
        ApiResponse<CertRequest> CsrIdGetWithHttpInfo(Guid? id);

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>CertRequestStatus</returns>
        CertRequestStatus CsrIdStatusGet(Guid? id);

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>ApiResponse of CertRequestStatus</returns>
        ApiResponse<CertRequestStatus> CsrIdStatusGetWithHttpInfo(Guid? id);

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>CertRequestStatus</returns>
        CertRequestStatus CsrPost(CertRequestBody body = null);

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of CertRequestStatus</returns>
        ApiResponse<CertRequestStatus> CsrPostWithHttpInfo(CertRequestBody body = null);

        #endregion Synchronous Operations

        #region Asynchronous Operations

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of CertRequest</returns>
        Task<CertRequest> CsrIdGetAsync(Guid? id);

        /// <summary>
        ///     Retrieves a given certRequest, including all details
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of ApiResponse (CertRequest)</returns>
        Task<ApiResponse<CertRequest>> CsrIdGetAsyncWithHttpInfo(Guid? id);

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of CertRequestStatus</returns>
        Task<CertRequestStatus> CsrIdStatusGetAsync(Guid? id);

        /// <summary>
        ///     Retrieves issuance status of certRequest, including certificateId if issued
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate Request ID</param>
        /// <returns>Task of ApiResponse (CertRequestStatus)</returns>
        Task<ApiResponse<CertRequestStatus>> CsrIdStatusGetAsyncWithHttpInfo(Guid? id);

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of CertRequestStatus</returns>
        Task<CertRequestStatus> CsrPostAsync(CertRequestBody body = null);

        /// <summary>
        ///     Create a certificate request
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (CertRequestStatus)</returns>
        Task<ApiResponse<CertRequestStatus>> CsrPostAsyncWithHttpInfo(CertRequestBody body = null);

        #endregion Asynchronous Operations
    }
}