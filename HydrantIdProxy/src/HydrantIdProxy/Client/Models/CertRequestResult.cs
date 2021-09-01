using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertRequestResult : ICertRequestResult
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CertRequestStatus RequestStatus{ get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ErrorReturn ErrorReturn { get; set; }
    }
}
