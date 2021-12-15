using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class RenewalRequest : IRenewalRequest
    {
        [JsonProperty("reuseCsr", NullValueHandling = NullValueHandling.Ignore)]
        public bool ReuseCsr { get; set; }
        [JsonProperty("csr", NullValueHandling = NullValueHandling.Ignore)]
        public string Csr { get; set; }
    }
}
