using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
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

        [DataMember(Name = "tag", EmitDefaultValue = false)]
        public TagEnum? Tag { get; }


        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; }

        [DataMember(Name = "required", EmitDefaultValue = false)]
        public bool? Required { get; }

        [DataMember(Name = "modifiable", EmitDefaultValue = false)]
        public bool? Modifiable { get; }

        [DataMember(Name = "defaultValue", EmitDefaultValue = false)]
        public string DefaultValue { get; }

        [DataMember(Name = "copyAsFirstSAN", EmitDefaultValue = false)]
        public bool? CopyAsFirstSan { get; }


    }
}