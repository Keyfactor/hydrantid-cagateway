// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IPolicyEnabled
    {
        /// <summary>
        ///     Gets or Sets Ui
        /// </summary>
        bool? Ui { get; }

        /// <summary>
        ///     Gets or Sets Rest
        /// </summary>
        bool? Rest { get; }

        /// <summary>
        ///     Gets or Sets Acme
        /// </summary>
        bool? Acme { get; }

        /// <summary>
        ///     Gets or Sets Scep
        /// </summary>
        bool? Scep { get; }

        /// <summary>
        ///     Gets or Sets Est
        /// </summary>
        bool? Est { get; }

        /// <summary>
        ///     Returns true if PolicyEnabled instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyEnabled to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(PolicyEnabled input);

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