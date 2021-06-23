using System;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class Policy : IPolicy
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        [JsonProperty("apiId", NullValueHandling = NullValueHandling.Ignore)]
        public int? ApiId { get; }

        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyDetails Details { get; }

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyEnabled Enabled { get; }

        [JsonProperty("organizationId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OrganizationId { get; }

        [JsonProperty("certificateAuthorityId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? CertificateAuthorityId { get; }

    }
}