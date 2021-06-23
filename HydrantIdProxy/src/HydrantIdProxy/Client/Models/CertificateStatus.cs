using System;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertificateStatus : ICertificateStatus
    {

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; }

        [JsonProperty("revocationStatus", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationStatusEnum RevocationStatus { get; }

        [JsonProperty("revocationReason", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationReasons RevocationReason { get; }

        [JsonProperty("revocationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? RevocationDate { get; }

    }
}