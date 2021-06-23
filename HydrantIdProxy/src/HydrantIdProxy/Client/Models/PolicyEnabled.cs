using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyEnabled : IPolicyEnabled
    {
        [JsonProperty("ui", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ui { get; }

        [JsonProperty("rest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rest { get; }

        [JsonProperty("acme", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Acme { get; }

        [JsonProperty("scep", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scep { get; }

        [JsonProperty("est", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Est { get; }
    }
}