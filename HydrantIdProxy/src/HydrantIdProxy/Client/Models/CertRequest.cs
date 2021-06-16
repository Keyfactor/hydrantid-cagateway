using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequest : ICertRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceEnum
        {
            [EnumMember(Value = "ACM")] Acm = 1,

            [EnumMember(Value = "ACME")] Acme = 2,

            [EnumMember(Value = "EST")] Est = 3,

            [EnumMember(Value = "RESTv1")] ResTv1 = 4,

            [EnumMember(Value = "RESTv2")] ResTv2 = 5,

            [EnumMember(Value = "SCEP")] Scep = 6,

            [EnumMember(Value = "SOAP")] Soap = 7
        }

        [DataMember(Name = "source", EmitDefaultValue = false)]
        public SourceEnum Source { get; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }
        
        [DataMember(Name = "fingerprint", EmitDefaultValue = false)]
        public string Fingerprint { get; }

        [DataMember(Name = "csr", EmitDefaultValue = false)]
        public string Csr { get; }

        [DataMember(Name = "commonName", EmitDefaultValue = false)]
        public string CommonName { get; }

        [DataMember(Name = "details", EmitDefaultValue = false)]
        public Dictionary<string, object> Details { get; }

        [DataMember(Name = "issuanceStatus", EmitDefaultValue = false)]
        public IssuanceStatus IssuanceStatus { get; }

        [DataMember(Name = "createAt", EmitDefaultValue = false)]
        public DateTime? CreateAt { get; }

        [DataMember(Name = "policy", EmitDefaultValue = false)]
        public CertRequestPolicy Policy { get; }

        [DataMember(Name = "user", EmitDefaultValue = false)]
        public CertRequestUser User { get; }

    }
}