using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificate
    {
        Guid? Id { get; }
        string Serial { get; }
        string CommonName { get; }
        string SubjectDn { get; }
        string IssuerDn { get; }
        DateTime? NotBefore { get; }
        DateTime? NotAfter { get; }
        string SignatureAlgorithm { get; }
        RevocationStatusEnum RevocationStatus { get; }
        int? RevocationReason { get; }
        DateTime? RevocationDate { get; }
        string Pem { get; }
        bool? Imported { get; }
        DateTime? CreatedAt { get; }
        List<string> SaNs { get; }
        CertRequestPolicy Policy { get; }
        CertificateUser User { get; }
        CertRequestPolicy Account { get; }
        CertRequestPolicy Organization { get; }
        List<string> ExpiryNotifications { get; }
    }
}