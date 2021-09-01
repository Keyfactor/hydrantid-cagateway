using System;
using Keyfactor.HydrantId.Client.Models.Enums;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertificatesPayload
    {
        string CommonName { get;set; }
        string Serial { get;set; }
        DateTime? NotBefore { get;set; }
        DateTime? NotAfter { get;set; }
        bool? Expired { get;set; }
        RevocationStatusEnum Status { get;set; }
        Guid? Account { get;set; }
        Guid? Organization { get;set; }
        Guid? Policy { get;set; }
        int? Limit { get;set; }
        int? Offset { get;set; }
        string SortType { get;set; }
        SortDirectionEnum SortDirection { get;set; }
        bool? Pem { get;set; }
    }
}