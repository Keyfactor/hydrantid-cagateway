using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IRevokeCertificateReasonIssuerDn
    {
        RevocationReasons Reason { get; }
        string IssuerDn { get; }
    }
}