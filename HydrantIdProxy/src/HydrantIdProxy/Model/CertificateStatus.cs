using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Enums;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     CertificateStatus
    /// </summary>
    [DataContract]
    public class CertificateStatus : IEquatable<CertificateStatus>, IValidatableObject, ICertificateStatus
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificateStatus" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="revocationStatus">revocationStatus (required).</param>
        /// <param name="revocationReason">revocationReason.</param>
        /// <param name="revocationDate">revocationDate.</param>
        public CertificateStatus(Guid? id = default, RevocationStatusEnum revocationStatus = default,
            RevocationReasons revocationReason = default, DateTime? revocationDate = default)
        {
            // to ensure "id" is required (not null)
            if (id == null)
                throw new InvalidDataException("id is a required property for CertificateStatus and cannot be null");
            Id = id;
            // to ensure "revocationStatus" is required (not null)
            RevocationStatus = revocationStatus;
            RevocationReason = revocationReason;
            RevocationDate = revocationDate;
        }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets RevocationReason
        /// </summary>
        [DataMember(Name = "revocationReason", EmitDefaultValue = false)]
        public RevocationReasons RevocationReason { get; }

        /// <summary>
        ///     Gets or Sets RevocationDate
        /// </summary>
        [DataMember(Name = "revocationDate", EmitDefaultValue = false)]
        public DateTime? RevocationDate { get; }

        /// <summary>
        ///     Returns true if CertificateStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of CertificateStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertificateStatus input)
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
                    RevocationStatus == input.RevocationStatus ||
                    RevocationStatus.Equals(input.RevocationStatus)
                ) &&
                (
                    RevocationReason == input.RevocationReason ||
                    RevocationReason.Equals(input.RevocationReason)
                ) &&
                (
                    RevocationDate == input.RevocationDate ||
                    RevocationDate != null &&
                    RevocationDate.Equals(input.RevocationDate)
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
            sb.Append("class CertificateStatus {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  RevocationStatus: ").Append(RevocationStatus).Append("\n");
            sb.Append("  RevocationReason: ").Append(RevocationReason).Append("\n");
            sb.Append("  RevocationDate: ").Append(RevocationDate).Append("\n");
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
            return Equals(input as CertificateStatus);
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
                hashCode = hashCode * 59 + RevocationStatus.GetHashCode();
                hashCode = hashCode * 59 + RevocationReason.GetHashCode();
                if (RevocationDate != null)
                    hashCode = hashCode * 59 + RevocationDate.GetHashCode();
                return hashCode;
            }
        }
    }
}