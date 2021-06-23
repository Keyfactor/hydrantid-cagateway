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

            [EnumMember(Value = "RFC822NAME")] Rfc822Name = 3,

            [EnumMember(Value = "UPN")] Upn = 4
        }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public TagEnum? Tag { get; }
        
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get; }

        [JsonProperty("modifiable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Modifiable { get; }

        [JsonProperty("defaultValue", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultValue { get; }

    }
}