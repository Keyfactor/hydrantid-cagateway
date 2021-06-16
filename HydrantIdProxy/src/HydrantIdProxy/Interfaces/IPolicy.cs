using System;
using Keyfactor.HydrantId.Client.Models;

namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicy
    {
        Guid? Id { get; }
        string Name { get; }
        int? ApiId { get; }
        PolicyDetails Details { get; }
        PolicyEnabled Enabled { get; }
        Guid? OrganizationId { get; }
        Guid? CertificateAuthorityId { get; }
    }
}