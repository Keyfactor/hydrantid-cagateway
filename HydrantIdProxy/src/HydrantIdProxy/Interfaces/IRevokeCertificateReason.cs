using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IRevokeCertificateReason
    {
        RevocationReasons Reason { get; }
    }
}