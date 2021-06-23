using System.Collections.Generic;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetails : IPolicyDetails
    {
        [JsonProperty("validity", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyDetailsValidity Validity { get; }

        [JsonProperty("dnComponents", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsDnComponents> DnComponents { get; }

        [JsonProperty("subjectAltNames", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsSubjectAltNames> SubjectAltNames { get; }

        [JsonProperty("approvalRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ApprovalRequired { get; }

        [JsonProperty("expiryEmails", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyDetailsExpiryEmails ExpiryEmails { get; }

        [JsonProperty("customFields", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsCustomFields> CustomFields { get; }

        [JsonProperty("customExtensions", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsCustomExtensions> CustomExtensions { get; }

    }
}