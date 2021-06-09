using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequestBodyDnComponents
    {
        /// <summary>
        ///     Gets or Sets CN
        /// </summary>
        string Cn { get; }

        /// <summary>
        ///     Gets or Sets OU
        /// </summary>
        List<string> Ou { get; }

        /// <summary>
        ///     Gets or Sets O
        /// </summary>
        string O { get; }

        /// <summary>
        ///     Gets or Sets L
        /// </summary>
        string L { get; }

        /// <summary>
        ///     Gets or Sets ST
        /// </summary>
        string St { get; }

        /// <summary>
        ///     Gets or Sets C
        /// </summary>
        string C { get; }

        /// <summary>
        ///     Gets or Sets DC
        /// </summary>
        List<string> Dc { get; }

        /// <summary>
        ///     Returns true if CertRequestBodyDnComponents instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBodyDnComponents to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequestBodyDnComponents input);

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