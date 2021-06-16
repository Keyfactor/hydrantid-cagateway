using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestBodyDnComponents : ICertRequestBodyDnComponents
    {
        [DataMember(Name = "CN", EmitDefaultValue = false)]
        public string Cn { get;set; }

        [DataMember(Name = "OU", EmitDefaultValue = false)]
        public List<string> Ou { get;set; }

        [DataMember(Name = "O", EmitDefaultValue = false)]
        public string O { get;set; }

        [DataMember(Name = "L", EmitDefaultValue = false)]
        public string L { get;set; }

        [DataMember(Name = "ST", EmitDefaultValue = false)]
        public string St { get;set; }

        [DataMember(Name = "C", EmitDefaultValue = false)]
        public string C { get;set; }

        [DataMember(Name = "DC", EmitDefaultValue = false)]
        public List<string> Dc { get;set; }

    }
}