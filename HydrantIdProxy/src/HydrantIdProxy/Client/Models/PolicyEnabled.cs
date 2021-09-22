using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyEnabled : IPolicyEnabled
    {
        [JsonProperty("ui", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ui { get;set; }

        [JsonProperty("rest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Rest { get;set; }

        [JsonProperty("acme", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Acme { get;set; }

        [JsonProperty("scep", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scep { get;set; }

        [JsonProperty("est", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Est { get;set; }
    }
}