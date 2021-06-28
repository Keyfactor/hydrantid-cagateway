using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetailsDnComponents : IPolicyDetailsDnComponents
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TagEnum
        {
            [EnumMember(Value = "CN")] Cn = 1,

            [EnumMember(Value = "OU")] Ou = 2,

            [EnumMember(Value = "O")] O = 3,

            [EnumMember(Value = "L")] L = 4,

            [EnumMember(Value = "ST")] St = 5,

            [EnumMember(Value = "C")] C = 6,

            [EnumMember(Value = "DC")] Dc = 7
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

        [JsonProperty("copyAsFirstSAN", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CopyAsFirstSan { get;set; }


    }
}