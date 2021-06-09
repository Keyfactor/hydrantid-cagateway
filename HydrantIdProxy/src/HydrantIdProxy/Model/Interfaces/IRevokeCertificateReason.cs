using Keyfactor.HydrantId.Model.Enums;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IRevokeCertificateReason
    {
        /// <summary>
        ///     Gets or Sets Reason
        /// </summary>
        RevocationReasons Reason { get; }

        /// <summary>
        ///     Returns true if RevokeCertificateReason instances are equal
        /// </summary>
        /// <param name="input">Instance of RevokeCertificateReason to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(RevokeCertificateReason input);

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