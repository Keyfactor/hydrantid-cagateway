// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IPolicyDetailsValidity
    {
        /// <summary>
        ///     Gets or Sets Years
        /// </summary>
        string Years { get; }

        /// <summary>
        ///     Gets or Sets Months
        /// </summary>
        string Months { get; }

        /// <summary>
        ///     Gets or Sets Days
        /// </summary>
        string Days { get; }

        /// <summary>
        ///     Gets or Sets Required
        /// </summary>
        bool? Required { get; }

        /// <summary>
        ///     Gets or Sets Modifiable
        /// </summary>
        bool? Modifiable { get; }

        /// <summary>
        ///     Returns true if PolicyDetailsValidity instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyDetailsValidity to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(PolicyDetailsValidity input);

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