using System;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificateStatus
    {
        Guid? Id { get; }
        RevocationStatusEnum RevocationStatus { get; }
        RevocationReasons RevocationReason { get; }
        DateTime? RevocationDate { get; }

    }
}