using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetails
    {
        List<PolicyDetailsDnComponents> DnComponents { get;set; }
        List<PolicyDetailsSubjectAltNames> SubjectAltNames { get;set; }
        bool? ApprovalRequired { get;set; }
        PolicyDetailsExpiryEmails ExpiryEmails { get;set; }
        List<PolicyDetailsCustomFields> CustomFields { get;set; }
        List<PolicyDetailsCustomExtensions> CustomExtensions { get;set; }
    }
}