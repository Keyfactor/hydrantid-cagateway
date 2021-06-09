using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Enums;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     GetCertificatesPayload
    /// </summary>
    [DataContract]
    public class CertificatesPayload : IEquatable<CertificatesPayload>, IValidatableObject, ICertificatesPayload
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificatesPayload" /> class.
        /// </summary>
        /// <param name="commonName">commonName.</param>
        /// <param name="serial">serial.</param>
        /// <param name="notBefore">notBefore.</param>
        /// <param name="notAfter">notAfter.</param>
        /// <param name="expired">expired (default to false).</param>
        /// <param name="status">status.</param>
        /// <param name="account">account.</param>
        /// <param name="organization">organization.</param>
        /// <param name="policy">policy.</param>
        /// <param name="limit">limit (default to 10).</param>
        /// <param name="offset">offset (default to 0).</param>
        /// <param name="sortType">sortType.</param>
        /// <param name="sortDirection">sortDirection.</param>
        /// <param name="pem">pem.</param>
        public CertificatesPayload(string commonName = default, string serial = default, DateTime? notBefore = default,
            DateTime? notAfter = default, bool? expired = false, RevocationStatusEnum status = default,
            Guid? account = default, Guid? organization = default, Guid? policy = default, int? limit = 10,
            int? offset = 0, string sortType = default, SortDirectionEnum sortDirection = default, bool? pem = default)
        {
            CommonName = commonName;
            Serial = serial;
            NotBefore = notBefore;
            NotAfter = notAfter;
            // use default value if no "expired" provided
            if (expired == null)
                Expired = false;
            else
                Expired = expired;
            Status = status;
            Account = account;
            Organization = organization;
            Policy = policy;
            // use default value if no "limit" provided
            if (limit == null)
                Limit = 10;
            else
                Limit = limit;
            // use default value if no "offset" provided
            if (offset == null)
                Offset = 0;
            else
                Offset = offset;
            SortType = sortType;
            SortDirection = sortDirection;
            Pem = pem;
        }

        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        [DataMember(Name = "common_name", EmitDefaultValue = false)]
        public string CommonName { get; }

        /// <summary>
        ///     Gets or Sets Serial
        /// </summary>
        [DataMember(Name = "serial", EmitDefaultValue = false)]
        public string Serial { get; }

        /// <summary>
        ///     Gets or Sets NotBefore
        /// </summary>
        [DataMember(Name = "not_before", EmitDefaultValue = false)]
        public DateTime? NotBefore { get; }

        /// <summary>
        ///     Gets or Sets NotAfter
        /// </summary>
        [DataMember(Name = "not_after", EmitDefaultValue = false)]
        public DateTime? NotAfter { get; }

        /// <summary>
        ///     Gets or Sets Expired
        /// </summary>
        [DataMember(Name = "expired", EmitDefaultValue = false)]
        public bool? Expired { get; }

        /// <summary>
        ///     Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public RevocationStatusEnum Status { get; }

        /// <summary>
        ///     Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public Guid? Account { get; }

        /// <summary>
        ///     Gets or Sets Organization
        /// </summary>
        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public Guid? Organization { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public Guid? Policy { get; }

        /// <summary>
        ///     Gets or Sets Limit
        /// </summary>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int? Limit { get; }

        /// <summary>
        ///     Gets or Sets Offset
        /// </summary>
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public int? Offset { get; }

        /// <summary>
        ///     Gets or Sets SortType
        /// </summary>
        [DataMember(Name = "sort_type", EmitDefaultValue = false)]
        public string SortType { get; }

        /// <summary>
        ///     Gets or Sets SortDirection
        /// </summary>
        [DataMember(Name = "sort_direction", EmitDefaultValue = false)]
        public SortDirectionEnum SortDirection { get; }

        /// <summary>
        ///     Gets or Sets Pem
        /// </summary>
        [DataMember(Name = "pem", EmitDefaultValue = false)]
        public bool? Pem { get; }

        /// <summary>
        ///     Returns true if GetCertificatesPayload instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCertificatesPayload to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertificatesPayload input)
        {
            if (input == null)
                return false;

            return
                (
                    CommonName == input.CommonName ||
                    CommonName != null &&
                    CommonName.Equals(input.CommonName)
                ) &&
                (
                    Serial == input.Serial ||
                    Serial != null &&
                    Serial.Equals(input.Serial)
                ) &&
                (
                    NotBefore == input.NotBefore ||
                    NotBefore != null &&
                    NotBefore.Equals(input.NotBefore)
                ) &&
                (
                    NotAfter == input.NotAfter ||
                    NotAfter != null &&
                    NotAfter.Equals(input.NotAfter)
                ) &&
                (
                    Expired == input.Expired ||
                    Expired != null &&
                    Expired.Equals(input.Expired)
                ) &&
                (
                    Status == input.Status ||
                    Status.Equals(input.Status)
                ) &&
                (
                    Account == input.Account ||
                    Account != null &&
                    Account.Equals(input.Account)
                ) &&
                (
                    Organization == input.Organization ||
                    Organization != null &&
                    Organization.Equals(input.Organization)
                ) &&
                (
                    Policy == input.Policy ||
                    Policy != null &&
                    Policy.Equals(input.Policy)
                ) &&
                (
                    Limit == input.Limit ||
                    Limit != null &&
                    Limit.Equals(input.Limit)
                ) &&
                (
                    Offset == input.Offset ||
                    Offset != null &&
                    Offset.Equals(input.Offset)
                ) &&
                (
                    SortType == input.SortType ||
                    SortType != null &&
                    SortType.Equals(input.SortType)
                ) &&
                (
                    SortDirection == input.SortDirection ||
                    SortDirection.Equals(input.SortDirection)
                ) &&
                (
                    Pem == input.Pem ||
                    Pem != null &&
                    Pem.Equals(input.Pem)
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
            sb.Append("class GetCertificatesPayload {\n");
            sb.Append("  CommonName: ").Append(CommonName).Append("\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  NotBefore: ").Append(NotBefore).Append("\n");
            sb.Append("  NotAfter: ").Append(NotAfter).Append("\n");
            sb.Append("  Expired: ").Append(Expired).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Organization: ").Append(Organization).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Offset: ").Append(Offset).Append("\n");
            sb.Append("  SortType: ").Append(SortType).Append("\n");
            sb.Append("  SortDirection: ").Append(SortDirection).Append("\n");
            sb.Append("  Pem: ").Append(Pem).Append("\n");
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
            return Equals(input as CertificatesPayload);
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
                if (CommonName != null)
                    hashCode = hashCode * 59 + CommonName.GetHashCode();
                if (Serial != null)
                    hashCode = hashCode * 59 + Serial.GetHashCode();
                if (NotBefore != null)
                    hashCode = hashCode * 59 + NotBefore.GetHashCode();
                if (NotAfter != null)
                    hashCode = hashCode * 59 + NotAfter.GetHashCode();
                if (Expired != null)
                    hashCode = hashCode * 59 + Expired.GetHashCode();
                hashCode = hashCode * 59 + Status.GetHashCode();
                if (Account != null)
                    hashCode = hashCode * 59 + Account.GetHashCode();
                if (Organization != null)
                    hashCode = hashCode * 59 + Organization.GetHashCode();
                if (Policy != null)
                    hashCode = hashCode * 59 + Policy.GetHashCode();
                if (Limit != null)
                    hashCode = hashCode * 59 + Limit.GetHashCode();
                if (Offset != null)
                    hashCode = hashCode * 59 + Offset.GetHashCode();
                if (SortType != null)
                    hashCode = hashCode * 59 + SortType.GetHashCode();
                hashCode = hashCode * 59 + SortDirection.GetHashCode();
                if (Pem != null)
                    hashCode = hashCode * 59 + Pem.GetHashCode();
                return hashCode;
            }
        }
    }
}