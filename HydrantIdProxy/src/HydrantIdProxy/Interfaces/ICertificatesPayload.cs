using System;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesPayload
    {
        string CommonName { get; }
        string Serial { get; }
        DateTime? NotBefore { get; }
        DateTime? NotAfter { get; }
        bool? Expired { get; }
        RevocationStatusEnum Status { get; }
        Guid? Account { get; }
        Guid? Organization { get; }
        Guid? Policy { get; }
        int? Limit { get; }
        int? Offset { get; }
        string SortType { get; }
        SortDirectionEnum SortDirection { get; }
        bool? Pem { get; }
    }
}