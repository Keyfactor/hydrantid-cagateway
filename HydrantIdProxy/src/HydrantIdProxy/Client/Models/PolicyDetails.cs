using System.Collections.Generic;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class PolicyDetails : IPolicyDetails
    {
        [JsonProperty("dnComponents", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsDnComponents> DnComponents { get;set; }

        [JsonProperty("subjectAltNames", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsSubjectAltNames> SubjectAltNames { get;set; }

        [JsonProperty("approvalRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ApprovalRequired { get;set; }

        [JsonProperty("expiryEmails", NullValueHandling = NullValueHandling.Ignore)]
        public PolicyDetailsExpiryEmails ExpiryEmails { get;set; }

        [JsonProperty("customFields", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsCustomFields> CustomFields { get;set; }

        [JsonProperty("customExtensions", NullValueHandling = NullValueHandling.Ignore)]
        public List<PolicyDetailsCustomExtensions> CustomExtensions { get;set; }

    }
}