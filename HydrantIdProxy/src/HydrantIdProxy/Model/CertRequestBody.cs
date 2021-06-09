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
    ///     CertRequestBody
    /// </summary>
    [DataContract]
    public class CertRequestBody : IEquatable<CertRequestBody>, IValidatableObject, ICertRequestBody
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertRequestBody" /> class.
        /// </summary>
        /// <param name="policy">policy (required).</param>
        /// <param name="csr">csr (required).</param>
        /// <param name="validity">validity.</param>
        /// <param name="dnComponents">dnComponents (required).</param>
        /// <param name="subjectAltNames">subjectAltNames.</param>
        /// <param name="customFields">customFields.</param>
        /// <param name="customExtensions">customExtensions.</param>
        /// <param name="comment">comment.</param>
        /// <param name="expiryEmails">expiryEmails.</param>
        /// <param name="clearRemindersCertificateId">clearRemindersCertificateId.</param>
        public CertRequestBody(Guid? policy = default, string csr = default, CertRequestBodyValidity validity = default,
            CertRequestBodyDnComponents dnComponents = default,
            CertRequestBodySubjectAltNames subjectAltNames = default, Dictionary<string, object> customFields = default,
            Dictionary<string, object> customExtensions = default, string comment = default,
            List<string> expiryEmails = default, string clearRemindersCertificateId = default)
        {
            // to ensure "policy" is required (not null)
            if (policy == null)
                throw new InvalidDataException("policy is a required property for CertRequestBody and cannot be null");
            Policy = policy;
            // to ensure "csr" is required (not null)
            if (csr == null)
                throw new InvalidDataException("csr is a required property for CertRequestBody and cannot be null");
            Csr = csr;
            // to ensure "dnComponents" is required (not null)
            if (dnComponents == null)
                throw new InvalidDataException(
                    "dnComponents is a required property for CertRequestBody and cannot be null");
            DnComponents = dnComponents;
            Validity = validity;
            SubjectAltNames = subjectAltNames;
            CustomFields = customFields;
            CustomExtensions = customExtensions;
            Comment = comment;
            ExpiryEmails = expiryEmails;
            ClearRemindersCertificateId = clearRemindersCertificateId;
        }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public Guid? Policy { get; }

        /// <summary>
        ///     Gets or Sets Csr
        /// </summary>
        [DataMember(Name = "csr", EmitDefaultValue = false)]
        public string Csr { get; }

        /// <summary>
        ///     Gets or Sets Validity
        /// </summary>
        [DataMember(Name = "validity", EmitDefaultValue = false)]
        public CertRequestBodyValidity Validity { get; }

        /// <summary>
        ///     Gets or Sets DnComponents
        /// </summary>
        [DataMember(Name = "dnComponents", EmitDefaultValue = false)]
        public CertRequestBodyDnComponents DnComponents { get; }

        /// <summary>
        ///     Gets or Sets SubjectAltNames
        /// </summary>
        [DataMember(Name = "subjectAltNames", EmitDefaultValue = false)]
        public CertRequestBodySubjectAltNames SubjectAltNames { get; }

        /// <summary>
        ///     Gets or Sets CustomFields
        /// </summary>
        [DataMember(Name = "customFields", EmitDefaultValue = false)]
        public Dictionary<string, object> CustomFields { get; }

        /// <summary>
        ///     Gets or Sets CustomExtensions
        /// </summary>
        [DataMember(Name = "customExtensions", EmitDefaultValue = false)]
        public Dictionary<string, object> CustomExtensions { get; }

        /// <summary>
        ///     Gets or Sets Comment
        /// </summary>
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string Comment { get; }

        /// <summary>
        ///     Gets or Sets ExpiryEmails
        /// </summary>
        [DataMember(Name = "expiryEmails", EmitDefaultValue = false)]
        public List<string> ExpiryEmails { get; }

        /// <summary>
        ///     Gets or Sets ClearRemindersCertificateId
        /// </summary>
        [DataMember(Name = "clearRemindersCertificateId", EmitDefaultValue = false)]
        public string ClearRemindersCertificateId { get; }

        /// <summary>
        ///     Returns true if CertRequestBody instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertRequestBody input)
        {
            if (input == null)
                return false;

            return
                (
                    Policy == input.Policy ||
                    Policy != null &&
                    Policy.Equals(input.Policy)
                ) &&
                (
                    Csr == input.Csr ||
                    Csr != null &&
                    Csr.Equals(input.Csr)
                ) &&
                (
                    Validity.Equals(input.Validity) ||
                    Validity != null &&
                    Validity.Equals(input.Validity)
                ) &&
                (
                    DnComponents.Equals(input.DnComponents) ||
                    DnComponents != null &&
                    DnComponents.Equals(input.DnComponents)
                ) &&
                (
                    SubjectAltNames.Equals(input.SubjectAltNames) ||
                    SubjectAltNames != null &&
                    SubjectAltNames.Equals(input.SubjectAltNames)
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
                ) &&
                (
                    Comment == input.Comment ||
                    Comment != null &&
                    Comment.Equals(input.Comment)
                ) &&
                (
                    ExpiryEmails == input.ExpiryEmails ||
                    ExpiryEmails != null &&
                    input.ExpiryEmails != null &&
                    ExpiryEmails.SequenceEqual(input.ExpiryEmails)
                ) &&
                (
                    ClearRemindersCertificateId == input.ClearRemindersCertificateId ||
                    ClearRemindersCertificateId != null &&
                    ClearRemindersCertificateId.Equals(input.ClearRemindersCertificateId)
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
            sb.Append("class CertRequestBody {\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  Csr: ").Append(Csr).Append("\n");
            sb.Append("  Validity: ").Append(Validity).Append("\n");
            sb.Append("  DnComponents: ").Append(DnComponents).Append("\n");
            sb.Append("  SubjectAltNames: ").Append(SubjectAltNames).Append("\n");
            sb.Append("  CustomFields: ").Append(CustomFields).Append("\n");
            sb.Append("  CustomExtensions: ").Append(CustomExtensions).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  ExpiryEmails: ").Append(ExpiryEmails).Append("\n");
            sb.Append("  ClearRemindersCertificateId: ").Append(ClearRemindersCertificateId).Append("\n");
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
            return Equals(input as CertRequestBody);
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
                if (Policy != null)
                    hashCode = hashCode * 59 + Policy.GetHashCode();
                if (Csr != null)
                    hashCode = hashCode * 59 + Csr.GetHashCode();
                if (Validity != null)
                    hashCode = hashCode * 59 + Validity.GetHashCode();
                if (DnComponents != null)
                    hashCode = hashCode * 59 + DnComponents.GetHashCode();
                if (SubjectAltNames != null)
                    hashCode = hashCode * 59 + SubjectAltNames.GetHashCode();
                if (CustomFields != null)
                    hashCode = hashCode * 59 + CustomFields.GetHashCode();
                if (CustomExtensions != null)
                    hashCode = hashCode * 59 + CustomExtensions.GetHashCode();
                if (Comment != null)
                    hashCode = hashCode * 59 + Comment.GetHashCode();
                if (ExpiryEmails != null)
                    hashCode = hashCode * 59 + ExpiryEmails.GetHashCode();
                if (ClearRemindersCertificateId != null)
                    hashCode = hashCode * 59 + ClearRemindersCertificateId.GetHashCode();
                return hashCode;
            }
        }
    }
}