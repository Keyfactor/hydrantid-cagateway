using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class Certificate : ICertificate
    {
  
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        [DataMember(Name = "serial", EmitDefaultValue = false)]
        public string Serial { get; }

        [DataMember(Name = "commonName", EmitDefaultValue = false)]
        public string CommonName { get; }

        [DataMember(Name = "subjectDN", EmitDefaultValue = false)]
        public string SubjectDn { get; }

        [DataMember(Name = "issuerDN", EmitDefaultValue = false)]
        public string IssuerDn { get; }

        [DataMember(Name = "notBefore", EmitDefaultValue = false)]
        public DateTime? NotBefore { get; }

        [DataMember(Name = "notAfter", EmitDefaultValue = false)]
        public DateTime? NotAfter { get; }

        [DataMember(Name = "signatureAlgorithm", EmitDefaultValue = false)]
        public string SignatureAlgorithm { get; }

        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum RevocationStatus { get; }

        [DataMember(Name = "revocationReason", EmitDefaultValue = false)]
        public int? RevocationReason { get; }

        [DataMember(Name = "revocationDate", EmitDefaultValue = false)]
        public DateTime? RevocationDate { get; }

        [DataMember(Name = "pem", EmitDefaultValue = false)]
        public string Pem { get; }

        [DataMember(Name = "imported", EmitDefaultValue = false)]
        public bool? Imported { get; }

        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime? CreatedAt { get; }

        [DataMember(Name = "SANs", EmitDefaultValue = false)]
        public List<string> SaNs { get; }

        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public CertRequestPolicy Policy { get; }

        [DataMember(Name = "user", EmitDefaultValue = false)]
        public CertificateUser User { get; }

        [DataMember(Name = "account", EmitDefaultValue = false)]
        public CertRequestPolicy Account { get; }

        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public CertRequestPolicy Organization { get; }

        [DataMember(Name = "expiryNotifications", EmitDefaultValue = false)]
        public List<string> ExpiryNotifications { get; }

    }
}