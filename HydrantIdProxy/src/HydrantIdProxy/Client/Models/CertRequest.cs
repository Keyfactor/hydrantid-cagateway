using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
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

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public SourceEnum Source { get;set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get;set; }
        
        [JsonProperty("fingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public string Fingerprint { get;set; }

        [JsonProperty("csr", NullValueHandling = NullValueHandling.Ignore)]
        public string Csr { get;set; }

        [JsonProperty("commonName", NullValueHandling = NullValueHandling.Ignore)]
        public string CommonName { get;set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Details { get;set; }

        [JsonProperty("issuanceStatus", NullValueHandling = NullValueHandling.Ignore)]
        public IssuanceStatus IssuanceStatus { get;set; }

        [JsonProperty("createAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreateAt { get;set; }

        [JsonProperty("policy", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestPolicy Policy { get;set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestUser User { get;set; }

    }
}