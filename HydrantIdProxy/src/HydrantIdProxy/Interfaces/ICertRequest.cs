using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequest
    {
        CertRequest.SourceEnum Source { get;set; }
        Guid? Id { get;set; }
        string Fingerprint { get;set; }
        string Csr { get;set; }
        string CommonName { get;set; }
        Dictionary<string, object> Details { get;set; }
        IssuanceStatus IssuanceStatus { get;set; }
        DateTime? CreateAt { get;set; }
        CertRequestPolicy Policy { get;set; }
        CertRequestUser User { get;set; }

    }
}