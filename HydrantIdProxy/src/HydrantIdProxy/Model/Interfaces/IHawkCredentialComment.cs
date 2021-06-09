// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IHawkCredentialComment
    {
        /// <summary>
        ///     Gets or Sets Comments
        /// </summary>
        string Comments { get; }

        /// <summary>
        ///     Returns true if HawkCredentialComment instances are equal
        /// </summary>
        /// <param name="input">Instance of HawkCredentialComment to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(HawkCredentialComment input);

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