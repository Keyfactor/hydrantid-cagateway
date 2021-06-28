using System;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificateStatus
    {
        Guid? Id { get;set; }
        RevocationStatusEnum RevocationStatus { get;set; }
        RevocationReasons RevocationReason { get;set; }
        DateTime? RevocationDate { get;set; }

    }
}