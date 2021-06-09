using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     PolicyDetails
    /// </summary>
    [DataContract]
    public class PolicyDetails : IEquatable<PolicyDetails>, IValidatableObject, IPolicyDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolicyDetails" /> class.
        /// </summary>
        /// <param name="validity">validity.</param>
        /// <param name="dnComponents">dnComponents (required).</param>
        /// <param name="subjectAltNames">subjectAltNames.</param>
        /// <param name="approvalRequired">approvalRequired.</param>
        /// <param name="expiryEmails">expiryEmails.</param>
        /// <param name="customFields">customFields.</param>
        /// <param name="customExtensions">customExtensions.</param>
        public PolicyDetails(PolicyDetailsValidity validity = default,
            List<PolicyDetailsDnComponents> dnComponents = default,
            List<PolicyDetailsSubjectAltNames> subjectAltNames = default, bool? approvalRequired = default,
            PolicyDetailsExpiryEmails expiryEmails = default, List<PolicyDetailsCustomFields> customFields = default,
            List<PolicyDetailsCustomExtensions> customExtensions = default)
        {
            // to ensure "dnComponents" is required (not null)
            if (dnComponents == null)
                throw new InvalidDataException(
                    "dnComponents is a required property for PolicyDetails and cannot be null");
            DnComponents = dnComponents;
            Validity = validity;
            SubjectAltNames = subjectAltNames;
            ApprovalRequired = approvalRequired;
            ExpiryEmails = expiryEmails;
            CustomFields = customFields;
            CustomExtensions = customExtensions;
        }

        /// <summary>
        ///     Gets or Sets Validity
        /// </summary>
        [DataMember(Name = "validity", EmitDefaultValue = false)]
        public PolicyDetailsValidity Validity { get; }

        /// <summary>
        ///     Gets or Sets DnComponents
        /// </summary>
        [DataMember(Name = "dnComponents", EmitDefaultValue = false)]
        public List<PolicyDetailsDnComponents> DnComponents { get; }

        /// <summary>
        ///     Gets or Sets SubjectAltNames
        /// </summary>
        [DataMember(Name = "subjectAltNames", EmitDefaultValue = false)]
        public List<PolicyDetailsSubjectAltNames> SubjectAltNames { get; }

        /// <summary>
        ///     Gets or Sets ApprovalRequired
        /// </summary>
        [DataMember(Name = "approvalRequired", EmitDefaultValue = false)]
        public bool? ApprovalRequired { get; }

        /// <summary>
        ///     Gets or Sets ExpiryEmails
        /// </summary>
        [DataMember(Name = "expiryEmails", EmitDefaultValue = false)]
        public PolicyDetailsExpiryEmails ExpiryEmails { get; }

        /// <summary>
        ///     Gets or Sets CustomFields
        /// </summary>
        [DataMember(Name = "customFields", EmitDefaultValue = false)]
        public List<PolicyDetailsCustomFields> CustomFields { get; }

        /// <summary>
        ///     Gets or Sets CustomExtensions
        /// </summary>
        [DataMember(Name = "customExtensions", EmitDefaultValue = false)]
        public List<PolicyDetailsCustomExtensions> CustomExtensions { get; }

        /// <summary>
        ///     Returns true if PolicyDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyDetails input)
        {
            if (input == null)
                return false;

            return
                (
                    Validity.Equals(input.Validity) ||
                    Validity != null &&
                    Validity.Equals(input.Validity)
                ) &&
                (
                    DnComponents == input.DnComponents ||
                    DnComponents != null &&
                    input.DnComponents != null &&
                    DnComponents.SequenceEqual(input.DnComponents)
                ) &&
                (
                    SubjectAltNames == input.SubjectAltNames ||
                    SubjectAltNames != null &&
                    input.SubjectAltNames != null &&
                    SubjectAltNames.SequenceEqual(input.SubjectAltNames)
                ) &&
                (
                    ApprovalRequired == input.ApprovalRequired ||
                    ApprovalRequired != null &&
                    ApprovalRequired.Equals(input.ApprovalRequired)
                ) &&
                (
                    ExpiryEmails.Equals(input.ExpiryEmails) ||
                    ExpiryEmails != null &&
                    ExpiryEmails.Equals(input.ExpiryEmails)
                ) &&
                (
                    CustomFields == input.CustomFields ||
                    CustomFields != null &&
                    input.CustomFields != null &&
                    CustomFields.SequenceEqual(input.CustomFields)
                ) &&
                (
                    CustomExtensions == input.CustomExtensions ||
                    CustomExtensions != null &&
                    input.CustomExtensions != null &&
                    CustomExtensions.SequenceEqual(input.CustomExtensions)
                );
        }

        /// <summary>
        ///     To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }

        /// <summary>
        ///     Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PolicyDetails {\n");
            sb.Append("  Validity: ").Append(Validity).Append("\n");
            sb.Append("  DnComponents: ").Append(DnComponents).Append("\n");
            sb.Append("  SubjectAltNames: ").Append(SubjectAltNames).Append("\n");
            sb.Append("  ApprovalRequired: ").Append(ApprovalRequired).Append("\n");
            sb.Append("  ExpiryEmails: ").Append(ExpiryEmails).Append("\n");
            sb.Append("  CustomFields: ").Append(CustomFields).Append("\n");
            sb.Append("  CustomExtensions: ").Append(CustomExtensions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        ///     Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        ///     Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as PolicyDetails);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (Validity != null)
                    hashCode = hashCode * 59 + Validity.GetHashCode();
                if (DnComponents != null)
                    hashCode = hashCode * 59 + DnComponents.GetHashCode();
                if (SubjectAltNames != null)
                    hashCode = hashCode * 59 + SubjectAltNames.GetHashCode();
                if (ApprovalRequired != null)
                    hashCode = hashCode * 59 + ApprovalRequired.GetHashCode();
                if (ExpiryEmails != null)
                    hashCode = hashCode * 59 + ExpiryEmails.GetHashCode();
                if (CustomFields != null)
                    hashCode = hashCode * 59 + CustomFields.GetHashCode();
                if (CustomExtensions != null)
                    hashCode = hashCode * 59 + CustomExtensions.GetHashCode();
                return hashCode;
            }
        }
    }
}