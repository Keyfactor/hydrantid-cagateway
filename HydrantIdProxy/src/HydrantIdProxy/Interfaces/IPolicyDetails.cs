using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetails
    {
        PolicyDetailsValidity Validity { get; }
        List<PolicyDetailsDnComponents> DnComponents { get; }
        List<PolicyDetailsSubjectAltNames> SubjectAltNames { get; }
        bool? ApprovalRequired { get; }
        PolicyDetailsExpiryEmails ExpiryEmails { get; }
        List<PolicyDetailsCustomFields> CustomFields { get; }
        List<PolicyDetailsCustomExtensions> CustomExtensions { get; }
    }
}