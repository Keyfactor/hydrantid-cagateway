using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IRevokeCertificateReasonIssuerDn
    {
        RevocationReasons Reason { get;set; }
        string IssuerDn { get;set; }
    }
}