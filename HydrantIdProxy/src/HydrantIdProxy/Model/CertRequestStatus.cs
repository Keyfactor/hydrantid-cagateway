using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Enums;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     CertRequestStatus
    /// </summary>
    [DataContract]
    public class CertRequestStatus : IEquatable<CertRequestStatus>, IValidatableObject, ICertRequestStatus
    {
        /// <summary>
        ///     Defines RevocationStatus
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevocationStatusEnum
        {
            /// <summary>
            ///     Enum VALID for value: VALID
            /// </summary>
            [EnumMember(Value = "VALID")] Valid = 1,

            /// <summary>
            ///     Enum PENDING for value: PENDING
            /// </summary>
            [EnumMember(Value = "PENDING")] Pending = 2,

            /// <summary>
            ///     Enum INPROCESS for value: IN_PROCESS
            /// </summary>
            [EnumMember(Value = "IN_PROCESS")] InProcess = 3,

            /// <summary>
            ///     Enum REVOKED for value: REVOKED
            /// </summary>
            [EnumMember(Value = "REVOKED")] Revoked = 4,

            /// <summary>
            ///     Enum FAILED for value: FAILED
            /// </summary>
            [EnumMember(Value = "FAILED")] Failed = 5
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertRequestStatus" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="issuanceStatus">issuanceStatus (required).</param>
        /// <param name="issuanceStatusDetails">issuanceStatusDetails.</param>
        /// <param name="certificateId">certificateId.</param>
        /// <param name="revocationStatus">revocationStatus.</param>
        public CertRequestStatus(string id = default, IssuanceStatus issuanceStatus = default,
            Dictionary<string, object> issuanceStatusDetails = default, Guid? certificateId = default,
            RevocationStatusEnum? revocationStatus = default)
        {
            // to ensure "id" is required (not null)
            if (id == null)
                throw new InvalidDataException("id is a required property for CertRequestStatus and cannot be null");
            Id = id;
            // to ensure "issuanceStatus" is required (not null)
            IssuanceStatus = issuanceStatus;
            IssuanceStatusDetails = issuanceStatusDetails;
            CertificateId = certificateId;
            RevocationStatus = revocationStatus;
        }

        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum? RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        /// <summary>
        ///     Gets or Sets IssuanceStatus
        /// </summary>
        [DataMember(Name = "issuanceStatus", EmitDefaultValue = false)]
        public IssuanceStatus IssuanceStatus { get; }

        /// <summary>
        ///     Gets or Sets IssuanceStatusDetails
        /// </summary>
        [DataMember(Name = "issuanceStatusDetails", EmitDefaultValue = false)]
        public Dictionary<string, object> IssuanceStatusDetails { get; }

        /// <summary>
        ///     Gets or Sets CertificateId
        /// </summary>
        [DataMember(Name = "certificateId", EmitDefaultValue = false)]
        public Guid? CertificateId { get; }

        /// <summary>
        ///     Returns true if CertRequestStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequestStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertRequestStatus input)
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
                    IssuanceStatus == input.IssuanceStatus ||
                    IssuanceStatus.Equals(input.IssuanceStatus)
                ) &&
                (
                    IssuanceStatusDetails == input.IssuanceStatusDetails ||
                    IssuanceStatusDetails != null &&
                    input.IssuanceStatusDetails != null &&
                    IssuanceStatusDetails.SequenceEqual(input.IssuanceStatusDetails)
                ) &&
                (
                    CertificateId == input.CertificateId ||
                    CertificateId != null &&
                    CertificateId.Equals(input.CertificateId)
                ) &&
                (
                    RevocationStatus == input.RevocationStatus ||
                    RevocationStatus != null &&
                    RevocationStatus.Equals(input.RevocationStatus)
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
            sb.Append("class CertRequestStatus {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IssuanceStatus: ").Append(IssuanceStatus).Append("\n");
            sb.Append("  IssuanceStatusDetails: ").Append(IssuanceStatusDetails).Append("\n");
            sb.Append("  CertificateId: ").Append(CertificateId).Append("\n");
            sb.Append("  RevocationStatus: ").Append(RevocationStatus).Append("\n");
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
            return Equals(input as CertRequestStatus);
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
                hashCode = hashCode * 59 + IssuanceStatus.GetHashCode();
                if (IssuanceStatusDetails != null)
                    hashCode = hashCode * 59 + IssuanceStatusDetails.GetHashCode();
                if (CertificateId != null)
                    hashCode = hashCode * 59 + CertificateId.GetHashCode();
                if (RevocationStatus != null)
                    hashCode = hashCode * 59 + RevocationStatus.GetHashCode();
                return hashCode;
            }
        }
    }
}