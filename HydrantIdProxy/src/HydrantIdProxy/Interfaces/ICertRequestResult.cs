using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestResult
    {
        CertRequestStatus RequestStatus { get; }
        ErrorReturn ErrorReturn { get; }
    }
}