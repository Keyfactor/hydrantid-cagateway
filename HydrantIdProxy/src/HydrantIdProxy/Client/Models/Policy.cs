using System;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class Policy : IPolicy
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get;set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get;set; }

        [JsonProperty("apiId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ApiId { get;set; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyDetails Details { get;set; }

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyEnabled Enabled { get;set; }

        [JsonProperty("organizationId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OrganizationId { get;set; }

        [JsonProperty("certificateAuthorityId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? CertificateAuthorityId { get;set; }

    }
}