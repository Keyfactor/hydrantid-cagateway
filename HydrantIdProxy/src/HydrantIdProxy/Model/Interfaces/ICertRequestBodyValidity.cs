// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequestBodyValidity
    {
        /// <summary>
        ///     Gets or Sets Years
        /// </summary>
        int? Years { get; }

        /// <summary>
        ///     Gets or Sets Months
        /// </summary>
        int? Months { get; }

        /// <summary>
        ///     Gets or Sets Days
        /// </summary>
        int? Days { get; }

        /// <summary>
        ///     Returns true if CertRequestBodyValidity instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBodyValidity to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequestBodyValidity input);

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