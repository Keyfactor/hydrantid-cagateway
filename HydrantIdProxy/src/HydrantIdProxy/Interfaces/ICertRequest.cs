using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequest
    {
        CertRequest.SourceEnum Source { get; }
        Guid? Id { get; }
        string Fingerprint { get; }
        string Csr { get; }
        string CommonName { get; }
        Dictionary<string, object> Details { get; }
        IssuanceStatus IssuanceStatus { get; }
        DateTime? CreateAt { get; }
        CertRequestPolicy Policy { get; }
        CertRequestUser User { get; }

    }
}