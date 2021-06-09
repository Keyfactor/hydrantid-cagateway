using System.Collections.Generic;
// ReSharper disable InconsistentNaming
namespace Keyfactor.HydrantId.Model.Interfaces
{
    public interface IPolicyDetails
    {
        /// <summary>
        ///     Gets or Sets Validity
        /// </summary>
        PolicyDetailsValidity Validity { get; }

        /// <summary>
        ///     Gets or Sets DnComponents
        /// </summary>
        List<PolicyDetailsDnComponents> DnComponents { get; }

        /// <summary>
        ///     Gets or Sets SubjectAltNames
        /// </summary>
        List<PolicyDetailsSubjectAltNames> SubjectAltNames { get; }

        /// <summary>
        ///     Gets or Sets ApprovalRequired
        /// </summary>
        bool? ApprovalRequired { get; }

        /// <summary>
        ///     Gets or Sets ExpiryEmails
        /// </summary>
        PolicyDetailsExpiryEmails ExpiryEmails { get; }

        /// <summary>
        ///     Gets or Sets CustomFields
        /// </summary>
        List<PolicyDetailsCustomFields> CustomFields { get; }

        /// <summary>
        ///     Gets or Sets CustomExtensions
        /// </summary>
        List<PolicyDetailsCustomExtensions> CustomExtensions { get; }

        /// <summary>
        ///     Returns true if PolicyDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyDetails to be compared</param>
        /// <returns>Boolean</returns>
        bool Equals(PolicyDetails input);

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