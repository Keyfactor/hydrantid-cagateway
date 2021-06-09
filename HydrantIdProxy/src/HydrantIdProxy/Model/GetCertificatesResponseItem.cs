using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Keyfactor.HydrantId.Model.Enums;
using Keyfactor.HydrantId.Model.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     GetCertificatesResponseItem
    /// </summary>
    [DataContract]
    public class CertificatesResponseItem : IEquatable<CertificatesResponseItem>, IValidatableObject, ICertificatesResponseItem
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CertificatesResponseItem" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="commonName">commonName.</param>
        /// <param name="serial">serial.</param>
        /// <param name="notBefore">notBefore.</param>
        /// <param name="notAfter">notAfter.</param>
        /// <param name="revocationStatus">revocationStatus.</param>
        /// <param name="sANs">sANs.</param>
        /// <param name="policy">policy.</param>
        public CertificatesResponseItem(string id = default, string commonName = default, string serial = default,
            DateTime? notBefore = default, DateTime? notAfter = default,
            RevocationStatusEnum revocationStatus = default, List<string> sANs = default, NameObject policy = default)
        {
            Id = id;
            CommonName = commonName;
            Serial = serial;
            NotBefore = notBefore;
            NotAfter = notAfter;
            RevocationStatus = revocationStatus;
            SaNs = sANs;
            Policy = policy;
        }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        [DataMember(Name = "commonName", EmitDefaultValue = false)]
        public string CommonName { get; }

        /// <summary>
        ///     Gets or Sets Serial
        /// </summary>
        [DataMember(Name = "serial", EmitDefaultValue = false)]
        public string Serial { get; }

        /// <summary>
        ///     Gets or Sets NotBefore
        /// </summary>
        [DataMember(Name = "notBefore", EmitDefaultValue = false)]
        public DateTime? NotBefore { get; }

        /// <summary>
        ///     Gets or Sets NotAfter
        /// </summary>
        [DataMember(Name = "notAfter", EmitDefaultValue = false)]
        public DateTime? NotAfter { get; }

        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets SANs
        /// </summary>
        [DataMember(Name = "SANs", EmitDefaultValue = false)]
        public List<string> SaNs { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public NameObject Policy { get; }

        /// <summary>
        ///     Returns true if GetCertificatesResponseItem instances are equal
        /// </summary>
        /// <param name="input">Instance of GetCertificatesResponseItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CertificatesResponseItem input)
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
                    RevocationStatus == input.RevocationStatus ||
                    RevocationStatus.Equals(input.RevocationStatus)
                ) &&
                (
                    SaNs == input.SaNs ||
                    SaNs != null &&
                    input.SaNs != null &&
                    SaNs.SequenceEqual(input.SaNs)
                ) &&
                (
                    Policy.Equals(input.Policy) ||
                    Policy != null &&
                    Policy.Equals(input.Policy)
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
            sb.Append("class GetCertificatesResponseItem {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CommonName: ").Append(CommonName).Append("\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  NotBefore: ").Append(NotBefore).Append("\n");
            sb.Append("  NotAfter: ").Append(NotAfter).Append("\n");
            sb.Append("  RevocationStatus: ").Append(RevocationStatus).Append("\n");
            sb.Append("  SANs: ").Append(SaNs).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
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
            return Equals(input as CertificatesResponseItem);
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
                if (CommonName != null)
                    hashCode = hashCode * 59 + CommonName.GetHashCode();
                if (Serial != null)
                    hashCode = hashCode * 59 + Serial.GetHashCode();
                if (NotBefore != null)
                    hashCode = hashCode * 59 + NotBefore.GetHashCode();
                if (NotAfter != null)
                    hashCode = hashCode * 59 + NotAfter.GetHashCode();
                hashCode = hashCode * 59 + RevocationStatus.GetHashCode();
                if (SaNs != null)
                    hashCode = hashCode * 59 + SaNs.GetHashCode();
                if (Policy != null)
                    hashCode = hashCode * 59 + Policy.GetHashCode();
                return hashCode;
            }
        }
    }
}