using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class PolicyEnabled : IPolicyEnabled
    {
        [DataMember(Name = "ui", EmitDefaultValue = false)]
        public bool? Ui { get; }

        [DataMember(Name = "rest", EmitDefaultValue = false)]
        public bool? Rest { get; }

        [DataMember(Name = "acme", EmitDefaultValue = false)]
        public bool? Acme { get; }

        [DataMember(Name = "scep", EmitDefaultValue = false)]
        public bool? Scep { get; }

        [DataMember(Name = "est", EmitDefaultValue = false)]
        public bool? Est { get; }
    }
}