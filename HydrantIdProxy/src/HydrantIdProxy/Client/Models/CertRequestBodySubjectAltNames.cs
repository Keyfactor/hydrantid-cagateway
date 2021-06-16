using System.Collections.Generic;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestBodySubjectAltNames : ICertRequestBodySubjectAltNames
    {
        [DataMember(Name = "DNSNAME", EmitDefaultValue = false)]
        public List<string> Dnsname { get; }

        [DataMember(Name = "IPADDRESS", EmitDefaultValue = false)]
        public List<string> Ipaddress { get; }

        [DataMember(Name = "RFC822NAME", EmitDefaultValue = false)]
        public List<string> Rfc822Name { get; }

        [DataMember(Name = "UPN", EmitDefaultValue = false)]
        public List<string> Upn { get; }

    }
}