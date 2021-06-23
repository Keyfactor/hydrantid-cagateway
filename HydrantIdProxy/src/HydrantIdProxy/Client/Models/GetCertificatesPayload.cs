using System;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class CertificatesPayload : ICertificatesPayload
    {

        [JsonProperty("common_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CommonName { get; set; }

        [JsonProperty("serial", NullValueHandling = NullValueHandling.Ignore)]
        public string Serial { get; set; }

        [JsonProperty("not_before", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotBefore { get; set; }

        [JsonProperty("not_after", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NotAfter { get; set; }

        [JsonProperty("expired", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Expired { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public RevocationStatusEnum Status { get; set; }

        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Account { get; set; }

        [JsonProperty("organization", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Organization { get; set; }

        [JsonProperty("policy", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Policy { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }

        [JsonProperty("sort_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SortType { get; set; }

        [JsonProperty("sort_direction", NullValueHandling = NullValueHandling.Ignore)]
        public SortDirectionEnum SortDirection { get; set; }

        [JsonProperty("pem", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Pem { get; set; }

    }
}