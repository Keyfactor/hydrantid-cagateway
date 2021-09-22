using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestStatus
    {
        CertRequestStatus.RevocationStatusEnum? RevocationStatus { get;set; }
        string Id { get;set; }
        IssuanceStatus IssuanceStatus { get;set; }
        Dictionary<string, object> IssuanceStatusDetails { get;set; }
        Guid? CertificateId { get;set; }

    }
}