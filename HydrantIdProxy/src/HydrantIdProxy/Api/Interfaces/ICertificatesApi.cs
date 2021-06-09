using System;
using System.Threading.Tasks;
using Keyfactor.HydrantId.Client;
using Keyfactor.HydrantId.Client.Interfaces;
using Keyfactor.HydrantId.Model;

namespace Keyfactor.HydrantId.Api.Interfaces
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICertificatesApi : IApiAccessor
    {
        #region Synchronous Operations

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>byte[]</returns>
        byte[] CertificatesIdDerGet(Guid? id, bool? chain = null);

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>ApiResponse of byte[]</returns>
        ApiResponse<byte[]> CertificatesIdDerGetWithHttpInfo(Guid? id, bool? chain = null);

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Certificate</returns>
        Certificate CertificatesIdGet(Guid? id);

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>ApiResponse of Certificate</returns>
        ApiResponse<Certificate> CertificatesIdGetWithHttpInfo(Guid? id);

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>CertificateStatus</returns>
        CertificateStatus CertificatesIdPatch(RevokeCertificateReason body, string id);

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>ApiResponse of CertificateStatus</returns>
        ApiResponse<CertificateStatus> CertificatesIdPatchWithHttpInfo(RevokeCertificateReason body, string id);

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>byte[]</returns>
        byte[] CertificatesIdPemGet(Guid? id, bool? chain = null);

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>ApiResponse of byte[]</returns>
        ApiResponse<byte[]> CertificatesIdPemGetWithHttpInfo(Guid? id, bool? chain = null);

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>CertificateStatus</returns>
        CertificateStatus CertificatesIdStatusGet(string id);

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>ApiResponse of CertificateStatus</returns>
        ApiResponse<CertificateStatus> CertificatesIdStatusGetWithHttpInfo(string id);

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>GetCertificatesResponse</returns>
        CertificatesResponse CertificatesPost(CertificatesPayload body = null);

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>ApiResponse of GetCertificatesResponse</returns>
        ApiResponse<CertificatesResponse> CertificatesPostWithHttpInfo(CertificatesPayload body = null);

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>CertificateStatus</returns>
        CertificateStatus CertificatesSerialNumberPatch(RevokeCertificateReasonIssuerDn body, string serialNumber);

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>ApiResponse of CertificateStatus</returns>
        ApiResponse<CertificateStatus> CertificatesSerialNumberPatchWithHttpInfo(RevokeCertificateReasonIssuerDn body,
            string serialNumber);

        #endregion Synchronous Operations

        #region Asynchronous Operations

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of byte[]</returns>
        Task<byte[]> CertificatesIdDerGetAsync(Guid? id, bool? chain = null);

        /// <summary>
        ///     Download DER format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        Task<ApiResponse<byte[]>> CertificatesIdDerGetAsyncWithHttpInfo(Guid? id, bool? chain = null);

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of Certificate</returns>
        Task<Certificate> CertificatesIdGetAsync(Guid? id);

        /// <summary>
        ///     Get a specific certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of ApiResponse (Certificate)</returns>
        Task<ApiResponse<Certificate>> CertificatesIdGetAsyncWithHttpInfo(Guid? id);

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>Task of CertificateStatus</returns>
        Task<CertificateStatus> CertificatesIdPatchAsync(RevokeCertificateReason body, string id);

        /// <summary>
        ///     Revoke a certificate given a certificate id
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason.</param>
        /// <param name="id">Certificate id</param>
        /// <returns>Task of ApiResponse (CertificateStatus)</returns>
        Task<ApiResponse<CertificateStatus>> CertificatesIdPatchAsyncWithHttpInfo(RevokeCertificateReason body,
            string id);

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of byte[]</returns>
        Task<byte[]> CertificatesIdPemGetAsync(Guid? id, bool? chain = null);

        /// <summary>
        ///     Download PEM format certificate
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <param name="chain">Include Chain (optional)</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        Task<ApiResponse<byte[]>> CertificatesIdPemGetAsyncWithHttpInfo(Guid? id, bool? chain = null);

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of CertificateStatus</returns>
        Task<CertificateStatus> CertificatesIdStatusGetAsync(string id);

        /// <summary>
        ///     Get certificate status
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Certificate ID</param>
        /// <returns>Task of ApiResponse (CertificateStatus)</returns>
        Task<ApiResponse<CertificateStatus>> CertificatesIdStatusGetAsyncWithHttpInfo(string id);

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>Task of GetCertificatesResponse</returns>
        Task<CertificatesResponse> CertificatesPostAsync(CertificatesPayload body = null);

        /// <summary>
        ///     Get Certificates
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Filter Certificates (optional)</param>
        /// <returns>Task of ApiResponse (GetCertificatesResponse)</returns>
        Task<ApiResponse<CertificatesResponse>> CertificatesPostAsyncWithHttpInfo(CertificatesPayload body = null);

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>Task of CertificateStatus</returns>
        Task<CertificateStatus> CertificatesSerialNumberPatchAsync(RevokeCertificateReasonIssuerDn body,
            string serialNumber);

        /// <summary>
        ///     Revoke a certificate given a serialNumber and issuerDN
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">Revocation reason and issuer DN</param>
        /// <param name="serialNumber">Serial number in hexadecimal format.</param>
        /// <returns>Task of ApiResponse (CertificateStatus)</returns>
        Task<ApiResponse<CertificateStatus>> CertificatesSerialNumberPatchAsyncWithHttpInfo(
            RevokeCertificateReasonIssuerDn body, string serialNumber);

        #endregion Asynchronous Operations
    }
}