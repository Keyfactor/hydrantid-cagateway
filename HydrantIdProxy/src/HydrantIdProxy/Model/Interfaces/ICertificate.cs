using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Model.Enums;

// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertificate
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets Serial
        /// </summary>
        string Serial { get; }

        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        string CommonName { get; }

        /// <summary>
        ///     Gets or Sets SubjectDN
        /// </summary>
        string SubjectDn { get; }

        /// <summary>
        ///     Gets or Sets IssuerDN
        /// </summary>
        string IssuerDn { get; }

        /// <summary>
        ///     Gets or Sets NotBefore
        /// </summary>
        DateTime? NotBefore { get; }

        /// <summary>
        ///     Gets or Sets NotAfter
        /// </summary>
        DateTime? NotAfter { get; }

        /// <summary>
        ///     Gets or Sets SignatureAlgorithm
        /// </summary>
        string SignatureAlgorithm { get; }

        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        RevocationStatusEnum RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets RevocationReason
        /// </summary>
        int? RevocationReason { get; }

        /// <summary>
        ///     Gets or Sets RevocationDate
        /// </summary>
        DateTime? RevocationDate { get; }

        /// <summary>
        ///     Gets or Sets Pem
        /// </summary>
        string Pem { get; }

        /// <summary>
        ///     Gets or Sets Imported
        /// </summary>
        bool? Imported { get; }

        /// <summary>
        ///     Gets or Sets CreatedAt
        /// </summary>
        DateTime? CreatedAt { get; }

        /// <summary>
        ///     Gets or Sets SANs
        /// </summary>
        List<string> SaNs { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        CertRequestPolicy Policy { get; }

        /// <summary>
        ///     Gets or Sets User
        /// </summary>
        CertificateUser User { get; }

        /// <summary>
        ///     Gets or Sets Account
        /// </summary>
        CertRequestPolicy Account { get; }

        /// <summary>
        ///     Gets or Sets Organization
        /// </summary>
        CertRequestPolicy Organization { get; }

        /// <summary>
        ///     Gets or Sets ExpiryNotifications
        /// </summary>
        List<string> ExpiryNotifications { get; }

        /// <summary>
        ///     Returns true if Certificate instances are equal
        /// </summary>
        /// <param name="input">Instance of Certificate to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(Certificate input);

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