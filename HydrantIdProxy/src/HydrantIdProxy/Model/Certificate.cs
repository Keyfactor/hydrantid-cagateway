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

namespace Keyfactor.HydrantId.Model
{
    /// <summary>
    ///     Certificate
    /// </summary>
    [DataContract]
    public class Certificate : IEquatable<Certificate>, IValidatableObject, ICertificate
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Certificate" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="serial">serial (required).</param>
        /// <param name="commonName">commonName (required).</param>
        /// <param name="subjectDn">subjectDN (required).</param>
        /// <param name="issuerDn">issuerDN (required).</param>
        /// <param name="notBefore">notBefore (required).</param>
        /// <param name="notAfter">notAfter (required).</param>
        /// <param name="signatureAlgorithm">signatureAlgorithm (required).</param>
        /// <param name="revocationStatus">revocationStatus (required).</param>
        /// <param name="revocationReason">revocationReason (required).</param>
        /// <param name="revocationDate">revocationDate.</param>
        /// <param name="pem">pem (required).</param>
        /// <param name="imported">imported (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="sANs">sANs.</param>
        /// <param name="policy">policy.</param>
        /// <param name="user">user.</param>
        /// <param name="account">account.</param>
        /// <param name="organization">organization.</param>
        /// <param name="expiryNotifications">expiryNotifications.</param>
        public Certificate(Guid? id = default, string serial = default, string commonName = default,
            string subjectDn = default, string issuerDn = default, DateTime? notBefore = default,
            DateTime? notAfter = default, string signatureAlgorithm = default,
            RevocationStatusEnum revocationStatus = default, int? revocationReason = default,
            DateTime? revocationDate = default, string pem = default, bool? imported = default,
            DateTime? createdAt = default, List<string> sANs = default, CertRequestPolicy policy = default,
            CertificateUser user = default, CertRequestPolicy account = default,
            CertRequestPolicy organization = default, List<string> expiryNotifications = default)
        {
            // to ensure "id" is required (not null)
            if (id == null)
                throw new InvalidDataException("id is a required property for Certificate and cannot be null");
            Id = id;
            // to ensure "serial" is required (not null)
            if (serial == null)
                throw new InvalidDataException("serial is a required property for Certificate and cannot be null");
            Serial = serial;
            // to ensure "commonName" is required (not null)
            if (commonName == null)
                throw new InvalidDataException("commonName is a required property for Certificate and cannot be null");
            CommonName = commonName;
            // to ensure "subjectDN" is required (not null)
            if (subjectDn == null)
                throw new InvalidDataException("subjectDN is a required property for Certificate and cannot be null");
            SubjectDn = subjectDn;
            // to ensure "issuerDN" is required (not null)
            if (issuerDn == null)
                throw new InvalidDataException("issuerDN is a required property for Certificate and cannot be null");
            IssuerDn = issuerDn;
            // to ensure "notBefore" is required (not null)
            if (notBefore == null)
                throw new InvalidDataException("notBefore is a required property for Certificate and cannot be null");
            NotBefore = notBefore;
            // to ensure "notAfter" is required (not null)
            if (notAfter == null)
                throw new InvalidDataException("notAfter is a required property for Certificate and cannot be null");
            NotAfter = notAfter;
            // to ensure "signatureAlgorithm" is required (not null)
            if (signatureAlgorithm == null)
                throw new InvalidDataException(
                    "signatureAlgorithm is a required property for Certificate and cannot be null");
            SignatureAlgorithm = signatureAlgorithm;
            // to ensure "revocationStatus" is required (not null)
            RevocationStatus = revocationStatus;
            // to ensure "revocationReason" is required (not null)
            if (revocationReason == null)
                throw new InvalidDataException(
                    "revocationReason is a required property for Certificate and cannot be null");
            RevocationReason = revocationReason;
            // to ensure "pem" is required (not null)
            if (pem == null)
                throw new InvalidDataException("pem is a required property for Certificate and cannot be null");
            Pem = pem;
            // to ensure "imported" is required (not null)
            if (imported == null)
                throw new InvalidDataException("imported is a required property for Certificate and cannot be null");
            Imported = imported;
            // to ensure "createdAt" is required (not null)
            if (createdAt == null)
                throw new InvalidDataException("createdAt is a required property for Certificate and cannot be null");
            CreatedAt = createdAt;
            RevocationDate = revocationDate;
            SaNs = sANs;
            Policy = policy;
            User = user;
            Account = account;
            Organization = organization;
            ExpiryNotifications = expiryNotifications;
        }

        /// <summary>
        ///     Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        /// <summary>
        ///     Gets or Sets Serial
        /// </summary>
        [DataMember(Name = "serial", EmitDefaultValue = false)]
        public string Serial { get; }

        /// <summary>
        ///     Gets or Sets CommonName
        /// </summary>
        [DataMember(Name = "commonName", EmitDefaultValue = false)]
        public string CommonName { get; }

        /// <summary>
        ///     Gets or Sets SubjectDN
        /// </summary>
        [DataMember(Name = "subjectDN", EmitDefaultValue = false)]
        public string SubjectDn { get; }

        /// <summary>
        ///     Gets or Sets IssuerDN
        /// </summary>
        [DataMember(Name = "issuerDN", EmitDefaultValue = false)]
        public string IssuerDn { get; }

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
        ///     Gets or Sets SignatureAlgorithm
        /// </summary>
        [DataMember(Name = "signatureAlgorithm", EmitDefaultValue = false)]
        public string SignatureAlgorithm { get; }

        /// <summary>
        ///     Gets or Sets RevocationStatus
        /// </summary>
        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum RevocationStatus { get; }

        /// <summary>
        ///     Gets or Sets RevocationReason
        /// </summary>
        [DataMember(Name = "revocationReason", EmitDefaultValue = false)]
        public int? RevocationReason { get; }

        /// <summary>
        ///     Gets or Sets RevocationDate
        /// </summary>
        [DataMember(Name = "revocationDate", EmitDefaultValue = false)]
        public DateTime? RevocationDate { get; }

        /// <summary>
        ///     Gets or Sets Pem
        /// </summary>
        [DataMember(Name = "pem", EmitDefaultValue = false)]
        public string Pem { get; }

        /// <summary>
        ///     Gets or Sets Imported
        /// </summary>
        [DataMember(Name = "imported", EmitDefaultValue = false)]
        public bool? Imported { get; }

        /// <summary>
        ///     Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime? CreatedAt { get; }

        /// <summary>
        ///     Gets or Sets SANs
        /// </summary>
        [DataMember(Name = "SANs", EmitDefaultValue = false)]
        public List<string> SaNs { get; }

        /// <summary>
        ///     Gets or Sets Policy
        /// </summary>
        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public CertRequestPolicy Policy { get; }

        /// <summary>
        ///     Gets or Sets User
        /// </summary>
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public CertificateUser User { get; }

        /// <summary>
        ///     Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public CertRequestPolicy Account { get; }

        /// <summary>
        ///     Gets or Sets Organization
        /// </summary>
        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public CertRequestPolicy Organization { get; }

        /// <summary>
        ///     Gets or Sets ExpiryNotifications
        /// </summary>
        [DataMember(Name = "expiryNotifications", EmitDefaultValue = false)]
        public List<string> ExpiryNotifications { get; }

        /// <summary>
        ///     Returns true if Certificate instances are equal
        /// </summary>
        /// <param name="input">Instance of Certificate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Certificate input)
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
                    Serial == input.Serial ||
                    Serial != null &&
                    Serial.Equals(input.Serial)
                ) &&
                (
                    CommonName == input.CommonName ||
                    CommonName != null &&
                    CommonName.Equals(input.CommonName)
                ) &&
                (
                    SubjectDn == input.SubjectDn ||
                    SubjectDn != null &&
                    SubjectDn.Equals(input.SubjectDn)
                ) &&
                (
                    IssuerDn == input.IssuerDn ||
                    IssuerDn != null &&
                    IssuerDn.Equals(input.IssuerDn)
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
                    SignatureAlgorithm == input.SignatureAlgorithm ||
                    SignatureAlgorithm != null &&
                    SignatureAlgorithm.Equals(input.SignatureAlgorithm)
                ) &&
                (
                    RevocationStatus == input.RevocationStatus ||
                    RevocationStatus.Equals(input.RevocationStatus)
                ) &&
                (
                    RevocationReason == input.RevocationReason ||
                    RevocationReason != null &&
                    RevocationReason.Equals(input.RevocationReason)
                ) &&
                (
                    RevocationDate == input.RevocationDate ||
                    RevocationDate != null &&
                    RevocationDate.Equals(input.RevocationDate)
                ) &&
                (
                    Pem == input.Pem ||
                    Pem != null &&
                    Pem.Equals(input.Pem)
                ) &&
                (
                    Imported == input.Imported ||
                    Imported != null &&
                    Imported.Equals(input.Imported)
                ) &&
                (
                    CreatedAt == input.CreatedAt ||
                    CreatedAt != null &&
                    CreatedAt.Equals(input.CreatedAt)
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
                ) &&
                (
                    User.Equals(input.User) ||
                    User != null &&
                    User.Equals(input.User)
                ) &&
                (
                    Account.Equals(input.Account) ||
                    Account != null &&
                    Account.Equals(input.Account)
                ) &&
                (
                    Organization.Equals(input.Organization) ||
                    Organization != null &&
                    Organization.Equals(input.Organization)
                ) &&
                (
                    ExpiryNotifications == input.ExpiryNotifications ||
                    ExpiryNotifications != null &&
                    input.ExpiryNotifications != null &&
                    ExpiryNotifications.SequenceEqual(input.ExpiryNotifications)
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
            sb.Append("class Certificate {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  CommonName: ").Append(CommonName).Append("\n");
            sb.Append("  SubjectDN: ").Append(SubjectDn).Append("\n");
            sb.Append("  IssuerDN: ").Append(IssuerDn).Append("\n");
            sb.Append("  NotBefore: ").Append(NotBefore).Append("\n");
            sb.Append("  NotAfter: ").Append(NotAfter).Append("\n");
            sb.Append("  SignatureAlgorithm: ").Append(SignatureAlgorithm).Append("\n");
            sb.Append("  RevocationStatus: ").Append(RevocationStatus).Append("\n");
            sb.Append("  RevocationReason: ").Append(RevocationReason).Append("\n");
            sb.Append("  RevocationDate: ").Append(RevocationDate).Append("\n");
            sb.Append("  Pem: ").Append(Pem).Append("\n");
            sb.Append("  Imported: ").Append(Imported).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  SANs: ").Append(SaNs).Append("\n");
            sb.Append("  Policy: ").Append(Policy).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Organization: ").Append(Organization).Append("\n");
            sb.Append("  ExpiryNotifications: ").Append(ExpiryNotifications).Append("\n");
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
            return Equals(input as Certificate);
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
                if (Serial != null)
                    hashCode = hashCode * 59 + Serial.GetHashCode();
                if (CommonName != null)
                    hashCode = hashCode * 59 + CommonName.GetHashCode();
                if (SubjectDn != null)
                    hashCode = hashCode * 59 + SubjectDn.GetHashCode();
                if (IssuerDn != null)
                    hashCode = hashCode * 59 + IssuerDn.GetHashCode();
                if (NotBefore != null)
                    hashCode = hashCode * 59 + NotBefore.GetHashCode();
                if (NotAfter != null)
                    hashCode = hashCode * 59 + NotAfter.GetHashCode();
                if (SignatureAlgorithm != null)
                    hashCode = hashCode * 59 + SignatureAlgorithm.GetHashCode();
                hashCode = hashCode * 59 + RevocationStatus.GetHashCode();
                if (RevocationReason != null)
                    hashCode = hashCode * 59 + RevocationReason.GetHashCode();
                if (RevocationDate != null)
                    hashCode = hashCode * 59 + RevocationDate.GetHashCode();
                if (Pem != null)
                    hashCode = hashCode * 59 + Pem.GetHashCode();
                if (Imported != null)
                    hashCode = hashCode * 59 + Imported.GetHashCode();
                if (CreatedAt != null)
                    hashCode = hashCode * 59 + CreatedAt.GetHashCode();
                if (SaNs != null)
                    hashCode = hashCode * 59 + SaNs.GetHashCode();
                if (Policy != null)
                    hashCode = hashCode * 59 + Policy.GetHashCode();
                if (User != null)
                    hashCode = hashCode * 59 + User.GetHashCode();
                if (Account != null)
                    hashCode = hashCode * 59 + Account.GetHashCode();
                if (Organization != null)
                    hashCode = hashCode * 59 + Organization.GetHashCode();
                if (ExpiryNotifications != null)
                    hashCode = hashCode * 59 + ExpiryNotifications.GetHashCode();
                return hashCode;
            }
        }
    }
}