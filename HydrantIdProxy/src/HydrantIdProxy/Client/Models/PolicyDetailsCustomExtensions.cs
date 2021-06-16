using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class PolicyDetailsCustomExtensions : IPolicyDetailsCustomExtensions
    {
        [DataMember(Name = "oid", EmitDefaultValue = false)]
        public string Oid { get; }

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