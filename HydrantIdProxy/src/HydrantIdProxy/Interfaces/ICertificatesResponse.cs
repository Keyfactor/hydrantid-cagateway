using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesResponse
    {
        int? Count { get;set; }
        List<CertificatesResponseItem> Items { get;set; }
    }
}