using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class RevokeCertificateReason : IRevokeCertificateReason
    {
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationReasons Reason { get; set; }

    }
}