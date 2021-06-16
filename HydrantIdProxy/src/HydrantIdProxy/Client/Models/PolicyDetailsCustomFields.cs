using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class PolicyDetailsCustomFields : IPolicyDetailsCustomFields
    {
        [DataMember(Name = "tag", EmitDefaultValue = false)]
        public string Tag { get; }

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