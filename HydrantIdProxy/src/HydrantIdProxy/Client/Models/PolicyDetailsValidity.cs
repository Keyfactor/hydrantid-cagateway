using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetailsValidity : IPolicyDetailsValidity
    {
        [JsonProperty("years", NullValueHandling = NullValueHandling.Ignore)]
        public string Years { get; }

        [JsonProperty("months", NullValueHandling = NullValueHandling.Ignore)]
        public string Months { get; }

        [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
        public string Days { get; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get; }

        [JsonProperty("modifiable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Modifiable { get; }

    }
}