using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Model.Enums;
// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequest
    {
        /// <summary>
        ///     Gets or Sets Source
        /// </summary>
        CertRequest.SourceEnum Source { get; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets Fingerprint
        /// </summary>
        string Fingerprint { get; }

        /// <summary>
        ///     Gets or Sets Csr
        /// </summary>
        string Csr { get; }

        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        string CommonName { get; }

        /// <summary>
        ///     Gets or Sets Details
        /// </summary>
        Dictionary<string, object> Details { get; }

        /// <summary>
        ///     Gets or Sets IssuanceStatus
        /// </summary>
        IssuanceStatus IssuanceStatus { get; }

        /// <summary>
        ///     Gets or Sets CreateAt
        /// </summary>
        DateTime? CreateAt { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        CertRequestPolicy Policy { get; }

        /// <summary>
        ///     Gets or Sets User
        /// </summary>
        CertRequestUser User { get; }

        /// <summary>
        ///     Returns true if CertRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequest to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequest input);

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