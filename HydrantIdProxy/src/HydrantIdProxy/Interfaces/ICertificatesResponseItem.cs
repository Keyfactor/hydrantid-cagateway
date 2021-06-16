using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesResponseItem
    {
        string Id { get; }
        string CommonName { get; }
        string Serial { get; }
        DateTime? NotBefore { get; }
        DateTime? NotAfter { get; }
        RevocationStatusEnum RevocationStatus { get; }
        List<string> SaNs { get; }
        NameObject Policy { get; }

    }
}