using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class RevokeCertificateReasonIssuerDn : IRevokeCertificateReasonIssuerDn
    {
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationReasons Reason { get;set; }

        [JsonProperty("issuerDN", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuerDn { get;set; }

    }
}