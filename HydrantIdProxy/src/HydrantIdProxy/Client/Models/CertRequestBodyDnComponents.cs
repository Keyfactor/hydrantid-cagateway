using System.Collections.Generic;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestBodyDnComponents : ICertRequestBodyDnComponents
    {
        [JsonProperty("CN", NullValueHandling = NullValueHandling.Ignore)]
        public string Cn { get; set; }

        [JsonProperty("OU", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Ou { get; set; }

        [JsonProperty("O", NullValueHandling = NullValueHandling.Ignore)]
        public string O { get; set; }

        [JsonProperty("L", NullValueHandling = NullValueHandling.Ignore)]
        public string L { get; set; }

        [JsonProperty("ST", NullValueHandling = NullValueHandling.Ignore)]
        public string St { get; set; }

        [JsonProperty("C", NullValueHandling = NullValueHandling.Ignore)]
        public string C { get; set; }

        [JsonProperty("DC", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dc { get; set; }

    }
}