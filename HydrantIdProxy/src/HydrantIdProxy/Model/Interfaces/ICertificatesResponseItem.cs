using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Model.Enums;
// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertificatesResponseItem
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        string Id { get; }

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
        ///     Gets or Sets RevocationStatus
        /// </summary>
        RevocationStatusEnum RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets SANs
        /// </summary>
        List<string> SaNs { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        NameObject Policy { get; }

        /// <summary>
        ///     Returns true if GetCertificatesResponseItem instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCertificatesResponseItem to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertificatesResponseItem input);

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