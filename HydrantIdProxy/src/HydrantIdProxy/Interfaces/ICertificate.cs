using System;
using System.Collections.Generic;
using Keyfactor.HydrantId.Client.Models;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificate
    {
        Guid? Id { get;set; }
        string Serial { get;set; }
        string CommonName { get;set; }
        string SubjectDn { get;set; }
        string IssuerDn { get;set; }
        DateTime? NotBefore { get;set; }
        DateTime? NotAfter { get;set; }
        string SignatureAlgorithm { get;set; }
        RevocationStatusEnum RevocationStatus { get;set; }
        int? RevocationReason { get;set; }
        DateTime? RevocationDate { get;set; }
        string Pem { get;set; }
        bool? Imported { get;set; }
        DateTime? CreatedAt { get;set; }
        List<string> SaNs { get;set; }
        CertRequestPolicy Policy { get;set; }
        CertificateUser User { get;set; }
        CertRequestPolicy Account { get;set; }
        CertRequestPolicy Organization { get;set; }
        List<string> ExpiryNotifications { get;set; }
    }
}