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
    ///     CertRequest
    /// </summary>
    [DataContract]
    public class CertRequest : IEquatable<CertRequest>, IValidatableObject, ICertRequest
    {
        /// <summary>
        ///     Defines Source
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceEnum
        {
            /// <summary>
            ///     Enum ACM for value: ACM
            /// </summary>
            [EnumMember(Value = "ACM")] Acm = 1,

            /// <summary>
            ///     Enum ACME for value: ACME
            /// </summary>
            [EnumMember(Value = "ACME")] Acme = 2,

            /// <summary>
            ///     Enum EST for value: EST
            /// </summary>
            [EnumMember(Value = "EST")] Est = 3,

            /// <summary>
            ///     Enum RESTv1 for value: RESTv1
            /// </summary>
            [EnumMember(Value = "RESTv1")] ResTv1 = 4,

            /// <summary>
            ///     Enum RESTv2 for value: RESTv2
            /// </summary>
            [EnumMember(Value = "RESTv2")] ResTv2 = 5,

            /// <summary>
            ///     Enum SCEP for value: SCEP
            /// </summary>
            [EnumMember(Value = "SCEP")] Scep = 6,

            /// <summary>
            ///     Enum SOAP for value: SOAP
            /// </summary>
            [EnumMember(Value = "SOAP")] Soap = 7
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CertRequest" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="source">source (required).</param>
        /// <param name="fingerprint">fingerprint (required).</param>
        /// <param name="csr">csr (required).</param>
        /// <param name="commonName">commonName (required).</param>
        /// <param name="details">details (required).</param>
        /// <param name="issuanceStatus">issuanceStatus (required).</param>
        /// <param name="createAt">createAt.</param>
        /// <param name="policy">policy.</param>
        /// <param name="user">user.</param>
        public CertRequest(Guid? id = default, SourceEnum source = default, string fingerprint = default,
            string csr = default, string commonName = default, Dictionary<string, object> details = default,
            IssuanceStatus issuanceStatus = default, DateTime? createAt = default, CertRequestPolicy policy = default,
            CertRequestUser user = default)
        {
            // to ensure "id" is required (not null)
            if (id == null)
                throw new InvalidDataException("id is a required property for CertRequest and cannot be null");
            Id = id;
            // to ensure "source" is required (not null)
            Source = source;
            // to ensure "fingerprint" is required (not null)
            if (fingerprint == null)
                throw new InvalidDataException("fingerprint is a required property for CertRequest and cannot be null");
            Fingerprint = fingerprint;
            // to ensure "csr" is required (not null)
            if (csr == null)
                throw new InvalidDataException("csr is a required property for CertRequest and cannot be null");
            Csr = csr;
            // to ensure "commonName" is required (not null)
            if (commonName == null)
                throw new InvalidDataException("commonName is a required property for CertRequest and cannot be null");
            CommonName = commonName;
            // to ensure "details" is required (not null)
            if (details == null)
                throw new InvalidDataException("details is a required property for CertRequest and cannot be null");
            Details = details;
            // to ensure "issuanceStatus" is required (not null)
            IssuanceStatus = issuanceStatus;
            CreateAt = createAt;
            Policy = policy;
            User = user;
        }

        /// <summary>
        ///     Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public SourceEnum Source { get; }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }


        /// <summary>
        ///     Gets or Sets Fingerprint
        /// </summary>
        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
        public string Fingerprint { get; }

        /// <summary>
        ///     Gets or Sets Csr
        /// </summary>
        [DataMember(Name = "csr", EmitDefaultValue = false)]
        public string Csr { get; }

        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        [DataMember(Name = "commonName", EmitDefaultValue = false)]
        public string CommonName { get; }

        /// <summary>
        ///     Gets or Sets Details
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false)]
        public Dictionary<string, object> Details { get; }

        /// <summary>
        ///     Gets or Sets IssuanceStatus
        /// </summary>
        [DataMember(Name = "issuanceStatus", EmitDefaultValue = false)]
        public IssuanceStatus IssuanceStatus { get; }

        /// <summary>
        ///     Gets or Sets CreateAt
        /// </summary>
        [DataMember(Name = "createAt", EmitDefaultValue = false)]
        public DateTime? CreateAt { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public CertRequestPolicy Policy { get; }

        /// <summary>
        ///     Gets or Sets User
        /// </summary>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public CertRequestUser User { get; }

        /// <summary>
        ///     Returns true if CertRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of CertRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertRequest input)
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
                    Source == input.Source ||
                    Source.Equals(input.Source)
                ) &&
                (
                    Fingerprint == input.Fingerprint ||
                    Fingerprint != null &&
                    Fingerprint.Equals(input.Fingerprint)
                ) &&
                (
                    Csr == input.Csr ||
                    Csr != null &&
                    Csr.Equals(input.Csr)
                ) &&
                (
                    CommonName == input.CommonName ||
                    CommonName != null &&
                    CommonName.Equals(input.CommonName)
                ) &&
                (
                    Details == input.Details ||
                    Details != null &&
                    input.Details != null &&
                    Details.SequenceEqual(input.Details)
                ) &&
                (
                    IssuanceStatus == input.IssuanceStatus ||
                    IssuanceStatus.Equals(input.IssuanceStatus)
                ) &&
                (
                    CreateAt == input.CreateAt ||
                    CreateAt != null &&
                    CreateAt.Equals(input.CreateAt)
                ) &&
                (
                    Policy.Equals(input.Policy) ||
                    Policy != null &&
                    Policy.Equals(input.Policy)
                ) &&
                (
                    User.Equals(input.User) ||
                    User != null &&
                    User.Equals(input.User)
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
            sb.Append("class CertRequest {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Fingerprint: ").Append(Fingerprint).Append("\n");
            sb.Append("  Csr: ").Append(Csr).Append("\n");
            sb.Append("  CommonName: ").Append(CommonName).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
            sb.Append("  IssuanceStatus: ").Append(IssuanceStatus).Append("\n");
            sb.Append("  CreateAt: ").Append(CreateAt).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
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
            return Equals(input as CertRequest);
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
                hashCode = hashCode * 59 + Source.GetHashCode();
                if (Fingerprint != null)
                    hashCode = hashCode * 59 + Fingerprint.GetHashCode();
                if (Csr != null)
                    hashCode = hashCode * 59 + Csr.GetHashCode();
                if (CommonName != null)
                    hashCode = hashCode * 59 + CommonName.GetHashCode();
                if (Details != null)
                    hashCode = hashCode * 59 + Details.GetHashCode();
                hashCode = hashCode * 59 + IssuanceStatus.GetHashCode();
                if (CreateAt != null)
                    hashCode = hashCode * 59 + CreateAt.GetHashCode();
                if (Policy != null)
                    hashCode = hashCode * 59 + Policy.GetHashCode();
                if (User != null)
                    hashCode = hashCode * 59 + User.GetHashCode();
                return hashCode;
            }
        }
    }
}