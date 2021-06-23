using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestBodyValidity : ICertRequestBodyValidity
    {
        [JsonProperty("years", NullValueHandling = NullValueHandling.Ignore)]
        public int? Years { get; set; }

        [JsonProperty("months", NullValueHandling = NullValueHandling.Ignore)]
        public int? Months { get; set; }

        [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
        public int? Days { get; set; }

    }
}