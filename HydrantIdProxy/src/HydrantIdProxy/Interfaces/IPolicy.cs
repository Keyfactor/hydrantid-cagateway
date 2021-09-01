using System;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicy
    {
        Guid? Id { get;set; }
        string Name { get;set; }
        int? ApiId { get;set; }
        PolicyDetails Details { get;set; }
        PolicyEnabled Enabled { get;set; }
        Guid? OrganizationId { get;set; }
        Guid? CertificateAuthorityId { get;set; }
    }
}