using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertificatesResponseItem : ICertificatesResponseItem
    {

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        [DataMember(Name = "commonName", EmitDefaultValue = false)]
        public string CommonName { get; }

        [DataMember(Name = "serial", EmitDefaultValue = false)]
        public string Serial { get; }

        [DataMember(Name = "notBefore", EmitDefaultValue = false)]
        public DateTime? NotBefore { get; }

        [DataMember(Name = "notAfter", EmitDefaultValue = false)]
        public DateTime? NotAfter { get; }

        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum RevocationStatus { get; }

        [DataMember(Name = "SANs", EmitDefaultValue = false)]
        public List<string> SaNs { get; }

        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public NameObject Policy { get; }

    }
}