using System;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IHawkCredential
    {
        /// <summary>
        ///     HAWK Identifier
        /// </summary>
        /// <value>HAWK Identifier</value>
        string Id { get; }

        /// <summary>
        ///     HAWK Key - *Only returned on create or roll*
        /// </summary>
        /// <value>HAWK Key - *Only returned on create or roll*</value>
        string Key { get; }

        /// <summary>
        ///     Comment for HAWK credential
        /// </summary>
        /// <value>Comment for HAWK credential</value>
        string Comments { get; }

        /// <summary>
        ///     Date/time HAWK credential last used
        /// </summary>
        /// <value>Date/time HAWK credential last used</value>
        DateTime? LastUsed { get; }

        /// <summary>
        ///     Date/time HAWK credential created
        /// </summary>
        /// <value>Date/time HAWK credential created</value>
        DateTime? CreatedAt { get; }

        /// <summary>
        ///     Date/time HAWK credential updated
        /// </summary>
        /// <value>Date/time HAWK credential updated</value>
        DateTime? UpdatedAt { get; }

        /// <summary>
        ///     Returns true if HawkCredential instances are equal
        /// </summary>
        /// <param name="input">Instance of HawkCredential to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(HawkCredential input);

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