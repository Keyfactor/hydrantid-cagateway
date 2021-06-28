using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesResponseItem
    {
        string Id { get;set; }
        string CommonName { get;set; }
        string Serial { get;set; }
        DateTime? NotBefore { get;set; }
        DateTime? NotAfter { get;set; }
        RevocationStatusEnum RevocationStatus { get;set; }
        List<string> SaNs { get;set; }
        NameObject Policy { get;set; }

    }
}