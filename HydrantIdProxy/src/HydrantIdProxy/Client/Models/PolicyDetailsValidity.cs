using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class PolicyDetailsValidity : IPolicyDetailsValidity
    {
        [DataMember(Name = "years", EmitDefaultValue = false)]
        public string Years { get; }

        [DataMember(Name = "months", EmitDefaultValue = false)]
        public string Months { get; }

        [DataMember(Name = "days", EmitDefaultValue = false)]
        public string Days { get; }

        [DataMember(Name = "required", EmitDefaultValue = false)]
        public bool? Required { get; }

        [DataMember(Name = "modifiable", EmitDefaultValue = false)]
        public bool? Modifiable { get; }

    }
}