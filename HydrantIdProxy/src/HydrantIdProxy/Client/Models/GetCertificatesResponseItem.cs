using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertificatesResponseItem : ICertificatesResponseItem
    {

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("commonName", NullValueHandling = NullValueHandling.Ignore)]
        public string CommonName { get; set; }

        [JsonProperty("serial", NullValueHandling = NullValueHandling.Ignore)]
        public string Serial { get; set; }

        [JsonProperty("notBefore", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotBefore { get; set; }

        [JsonProperty("notAfter", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotAfter { get; set; }

        [JsonProperty("revocationStatus", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationStatusEnum RevocationStatus { get; set; }

        [JsonProperty("SANs", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SaNs { get; set; }

        [JsonProperty("policy", NullValueHandling = NullValueHandling.Ignore)]
        public NameObject Policy { get; set; }

    }
}