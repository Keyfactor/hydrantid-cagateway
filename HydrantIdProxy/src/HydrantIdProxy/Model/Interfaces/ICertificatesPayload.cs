using System;
using Keyfactor.HydrantId.Model.Enums;
// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertificatesPayload
    {
        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        string CommonName { get; }

        /// <summary>
        ///     Gets or Sets Serial
        /// </summary>
        string Serial { get; }

        /// <summary>
        ///     Gets or Sets NotBefore
        /// </summary>
        DateTime? NotBefore { get; }

        /// <summary>
        ///     Gets or Sets NotAfter
        /// </summary>
        DateTime? NotAfter { get; }

        /// <summary>
        ///     Gets or Sets Expired
        /// </summary>
        bool? Expired { get; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        RevocationStatusEnum Status { get; }

        /// <summary>
        ///     Gets or Sets Account
        /// </summary>
        Guid? Account { get; }

        /// <summary>
        ///     Gets or Sets Organization
        /// </summary>
        Guid? Organization { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        Guid? Policy { get; }

        /// <summary>
        ///     Gets or Sets Limit
        /// </summary>
        int? Limit { get; }

        /// <summary>
        ///     Gets or Sets Offset
        /// </summary>
        int? Offset { get; }

        /// <summary>
        ///     Gets or Sets SortType
        /// </summary>
        string SortType { get; }

        /// <summary>
        ///     Gets or Sets SortDirection
        /// </summary>
        SortDirectionEnum SortDirection { get; }

        /// <summary>
        ///     Gets or Sets Pem
        /// </summary>
        bool? Pem { get; }

        /// <summary>
        ///     Returns true if GetCertificatesPayload instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCertificatesPayload to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertificatesPayload input);

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        string ToString();

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        string GetJson();

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(object input);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        int GetHashCode();
    }
}