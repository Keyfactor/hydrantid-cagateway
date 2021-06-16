using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestBodyValidity : ICertRequestBodyValidity
    {
        [DataMember(Name = "years", EmitDefaultValue = false)]
        public int? Years { get; }

        [DataMember(Name = "months", EmitDefaultValue = false)]
        public int? Months { get; }

        [DataMember(Name = "days", EmitDefaultValue = false)]
        public int? Days { get; }

    }
}