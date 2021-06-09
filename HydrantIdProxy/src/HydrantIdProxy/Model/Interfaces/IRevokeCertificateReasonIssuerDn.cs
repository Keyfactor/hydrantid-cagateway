using Keyfactor.HydrantId.Model.Enums;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IRevokeCertificateReasonIssuerDn
    {
        /// <summary>
        ///     Gets or Sets Reason
        /// </summary>
        RevocationReasons Reason { get; }

        /// <summary>
        ///     Issuer distinguished name
        /// </summary>
        /// <value>Issuer distinguished name</value>
        string IssuerDn { get; }

        /// <summary>
        ///     Returns true if RevokeCertificateReasonIssuerDN instances are equal
        /// </summary>
        /// <param name="input">Instance of RevokeCertificateReasonIssuerDN to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(RevokeCertificateReasonIssuerDn input);

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