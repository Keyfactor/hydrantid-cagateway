using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     Policy
    /// </summary>
    [DataContract]
    public class Policy : IEquatable<Policy>, IValidatableObject, IPolicy
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Policy" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="apiId">apiId (required).</param>
        /// <param name="details">details (required).</param>
        /// <param name="enabled">enabled (required).</param>
        /// <param name="organizationId">organizationId (required).</param>
        /// <param name="certificateAuthorityId">certificateAuthorityId (required).</param>
        public Policy(Guid? id = default, string name = default, int? apiId = default, PolicyDetails details = default,
            PolicyEnabled enabled = default, Guid? organizationId = default, Guid? certificateAuthorityId = default)
        {
            // to ensure "id" is required (not null)
            if (id == null)
                throw new InvalidDataException("id is a required property for Policy and cannot be null");
            Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
                throw new InvalidDataException("name is a required property for Policy and cannot be null");
            Name = name;
            // to ensure "apiId" is required (not null)
            if (apiId == null)
                throw new InvalidDataException("apiId is a required property for Policy and cannot be null");
            ApiId = apiId;
            // to ensure "details" is required (not null)
            if (details == null)
                throw new InvalidDataException("details is a required property for Policy and cannot be null");
            Details = details;
            // to ensure "enabled" is required (not null)
            if (enabled == null)
                throw new InvalidDataException("enabled is a required property for Policy and cannot be null");
            Enabled = enabled;
            // to ensure "organizationId" is required (not null)
            if (organizationId == null)
                throw new InvalidDataException("organizationId is a required property for Policy and cannot be null");
            OrganizationId = organizationId;
            // to ensure "certificateAuthorityId" is required (not null)
            if (certificateAuthorityId == null)
                throw new InvalidDataException(
                    "certificateAuthorityId is a required property for Policy and cannot be null");
            CertificateAuthorityId = certificateAuthorityId;
        }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

        /// <summary>
        ///     Gets or Sets ApiId
        /// </summary>
        [DataMember(Name = "apiId", EmitDefaultValue = false)]
        public int? ApiId { get; }

        /// <summary>
        ///     Gets or Sets Details
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false)]
        public PolicyDetails Details { get; }

        /// <summary>
        ///     Gets or Sets Enabled
        /// </summary>
        [DataMember(Name = "enabled", EmitDefaultValue = false)]
        public PolicyEnabled Enabled { get; }

        /// <summary>
        ///     Gets or Sets OrganizationId
        /// </summary>
        [DataMember(Name = "organizationId", EmitDefaultValue = false)]
        public Guid? OrganizationId { get; }

        /// <summary>
        ///     Gets or Sets CertificateAuthorityId
        /// </summary>
        [DataMember(Name = "certificateAuthorityId", EmitDefaultValue = false)]
        public Guid? CertificateAuthorityId { get; }

        /// <summary>
        ///     Returns true if Policy instances are equal
        /// </summary>
        /// <param name="input">Instance of Policy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Policy input)
        {
            if (input == null)
                return false;

            return
                (
                    Id == input.Id ||
                    Id != null &&
                    Id.Equals(input.Id)
                ) &&
                (
                    Name == input.Name ||
                    Name != null &&
                    Name.Equals(input.Name)
                ) &&
                (
                    ApiId == input.ApiId ||
                    ApiId != null &&
                    ApiId.Equals(input.ApiId)
                ) &&
                (
                    Details.Equals(input.Details) ||
                    Details != null &&
                    Details.Equals(input.Details)
                ) &&
                (
                    Enabled.Equals(input.Enabled) ||
                    Enabled != null &&
                    Enabled.Equals(input.Enabled)
                ) &&
                (
                    OrganizationId == input.OrganizationId ||
                    OrganizationId != null &&
                    OrganizationId.Equals(input.OrganizationId)
                ) &&
                (
                    CertificateAuthorityId == input.CertificateAuthorityId ||
                    CertificateAuthorityId != null &&
                    CertificateAuthorityId.Equals(input.CertificateAuthorityId)
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
            sb.Append("class Policy {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ApiId: ").Append(ApiId).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  Enabled: ").Append(Enabled).Append("\n");
            sb.Append("  OrganizationId: ").Append(OrganizationId).Append("\n");
            sb.Append("  CertificateAuthorityId: ").Append(CertificateAuthorityId).Append("\n");
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
            return Equals(input as Policy);
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (ApiId != null)
                    hashCode = hashCode * 59 + ApiId.GetHashCode();
                if (Details != null)
                    hashCode = hashCode * 59 + Details.GetHashCode();
                if (Enabled != null)
                    hashCode = hashCode * 59 + Enabled.GetHashCode();
                if (OrganizationId != null)
                    hashCode = hashCode * 59 + OrganizationId.GetHashCode();
                if (CertificateAuthorityId != null)
                    hashCode = hashCode * 59 + CertificateAuthorityId.GetHashCode();
                return hashCode;
            }
        }
    }
}