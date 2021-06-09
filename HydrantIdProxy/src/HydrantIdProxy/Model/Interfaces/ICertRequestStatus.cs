using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Model.Enums;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequestStatus
    {
        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        CertRequestStatus.RevocationStatusEnum? RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Gets or Sets IssuanceStatus
        /// </summary>
        IssuanceStatus IssuanceStatus { get; }

        /// <summary>
        ///     Gets or Sets IssuanceStatusDetails
        /// </summary>
        Dictionary<string, object> IssuanceStatusDetails { get; }

        /// <summary>
        ///     Gets or Sets CertificateId
        /// </summary>
        Guid? CertificateId { get; }

        /// <summary>
        ///     Returns true if CertRequestStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestStatus to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequestStatus input);

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