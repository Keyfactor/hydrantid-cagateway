using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestStatus
    {
        CertRequestStatus.RevocationStatusEnum? RevocationStatus { get; }
        string Id { get; }
        IssuanceStatus IssuanceStatus { get; }
        Dictionary<string, object> IssuanceStatusDetails { get; }
        Guid? CertificateId { get; }

    }
}