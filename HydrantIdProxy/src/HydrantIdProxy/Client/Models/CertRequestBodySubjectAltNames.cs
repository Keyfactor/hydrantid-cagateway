using System.Collections.Generic;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestBodySubjectAltNames : ICertRequestBodySubjectAltNames
    {
        [JsonProperty("DNSNAME", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dnsname { get; set; }

        [JsonProperty("IPADDRESS", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Ipaddress { get; set; }

        [JsonProperty("RFC822NAME", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Rfc822Name { get; set; }

        [JsonProperty("UPN", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Upn { get; set; }

    }
}