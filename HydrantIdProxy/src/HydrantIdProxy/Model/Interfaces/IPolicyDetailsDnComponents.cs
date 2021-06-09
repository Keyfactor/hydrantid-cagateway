// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IPolicyDetailsDnComponents
    {
        /// <summary>
        ///     Gets or Sets Tag
        /// </summary>
        PolicyDetailsDnComponents.TagEnum? Tag { get; }

        /// <summary>
        ///     Gets or Sets Label
        /// </summary>
        string Label { get; }

        /// <summary>
        ///     Gets or Sets Required
        /// </summary>
        bool? Required { get; }

        /// <summary>
        ///     Gets or Sets Modifiable
        /// </summary>
        bool? Modifiable { get; }

        /// <summary>
        ///     Gets or Sets DefaultValue
        /// </summary>
        string DefaultValue { get; }

        /// <summary>
        ///     Gets or Sets CopyAsFirstSAN
        /// </summary>
        bool? CopyAsFirstSan { get; }

        /// <summary>
        ///     Returns true if PolicyDetailsDnComponents instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyDetailsDnComponents to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(PolicyDetailsDnComponents input);

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