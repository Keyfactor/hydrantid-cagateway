// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IHawkCredentialDeleteResults
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Gets or Sets Deleted
        /// </summary>
        bool? Deleted { get; }

        /// <summary>
        ///     Returns true if HawkCredentialDeleteResults instances are equal
        /// </summary>
        /// <param name="input">Instance of HawkCredentialDeleteResults to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(HawkCredentialDeleteResults input);

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