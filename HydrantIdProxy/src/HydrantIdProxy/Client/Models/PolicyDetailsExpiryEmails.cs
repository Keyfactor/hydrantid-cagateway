using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class PolicyDetailsExpiryEmails : IPolicyDetailsExpiryEmails
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TagEnum
        {
            [EnumMember(Value = "expiryEmails")] ExpiryEmails = 1
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

    }
}