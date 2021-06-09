using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequestBodySubjectAltNames
    {
        /// <summary>
        ///     Gets or Sets DNSNAME
        /// </summary>
        List<string> Dnsname { get; }

        /// <summary>
        ///     Gets or Sets IPADDRESS
        /// </summary>
        List<string> Ipaddress { get; }

        /// <summary>
        ///     Gets or Sets RFC822NAME
        /// </summary>
        List<string> Rfc822Name { get; }

        /// <summary>
        ///     Gets or Sets UPN
        /// </summary>
        List<string> Upn { get; }

        /// <summary>
        ///     Returns true if CertRequestBodySubjectAltNames instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBodySubjectAltNames to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequestBodySubjectAltNames input);

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