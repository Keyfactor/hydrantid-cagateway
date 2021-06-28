using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetailsSubjectAltNames : IPolicyDetailsSubjectAltNames
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TagEnum
        {
            [EnumMember(Value = "DNSNAME")] DnsName = 1,

            [EnumMember(Value = "IPADDRESS")] IpAddress = 2,

            [EnumMember(Value = "RFS822NAME")] Rfs822Name = 3,

            [EnumMember(Value = "UPN")] Upn = 4
        }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public TagEnum? Tag { get;set; }
        
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get;set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get;set; }

        [JsonProperty("modifiable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Modifiable { get;set; }

        [JsonProperty("defaultValue", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultValue { get;set; }

    }
}