using System;
using Keyfactor.HydrantId.Model.Enums;

// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertificateStatus
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        RevocationStatusEnum RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets RevocationReason
        /// </summary>
        RevocationReasons RevocationReason { get; }

        /// <summary>
        ///     Gets or Sets RevocationDate
        /// </summary>
        DateTime? RevocationDate { get; }

        /// <summary>
        ///     Returns true if CertificateStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of CertificateStatus to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertificateStatus input);

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