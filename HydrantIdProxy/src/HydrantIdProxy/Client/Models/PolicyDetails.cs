using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class PolicyDetails : IPolicyDetails
    {
        [DataMember(Name = "validity", EmitDefaultValue = false)]
        public PolicyDetailsValidity Validity { get; }

        [DataMember(Name = "dnComponents", EmitDefaultValue = false)]
        public List<PolicyDetailsDnComponents> DnComponents { get; }

        [DataMember(Name = "subjectAltNames", EmitDefaultValue = false)]
        public List<PolicyDetailsSubjectAltNames> SubjectAltNames { get; }

        [DataMember(Name = "approvalRequired", EmitDefaultValue = false)]
        public bool? ApprovalRequired { get; }

        [DataMember(Name = "expiryEmails", EmitDefaultValue = false)]
        public PolicyDetailsExpiryEmails ExpiryEmails { get; }

        [DataMember(Name = "customFields", EmitDefaultValue = false)]
        public List<PolicyDetailsCustomFields> CustomFields { get; }

        [DataMember(Name = "customExtensions", EmitDefaultValue = false)]
        public List<PolicyDetailsCustomExtensions> CustomExtensions { get; }

    }
}