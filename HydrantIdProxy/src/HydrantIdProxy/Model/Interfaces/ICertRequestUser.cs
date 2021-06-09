using System;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface ICertRequestUser
    {
        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets FirstName
        /// </summary>
        string FirstName { get; }

        /// <summary>
        ///     Gets or Sets LastName
        /// </summary>
        string LastName { get; }

        /// <summary>
        ///     Returns true if CertRequestUser instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestUser to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(CertRequestUser input);

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