using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetailsValidity : IPolicyDetailsValidity
    {
        [JsonProperty("years", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Years { get;set; }

        [JsonProperty("months", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Months { get;set; }

        [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Days { get;set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Required { get;set; }

        [JsonProperty("modifiable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Modifiable { get;set; }

    }
}