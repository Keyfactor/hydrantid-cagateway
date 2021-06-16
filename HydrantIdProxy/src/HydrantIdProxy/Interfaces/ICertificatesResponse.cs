using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesResponse
    {
        int? Count { get; }
        List<CertificatesResponseItem> Items { get; }
    }
}