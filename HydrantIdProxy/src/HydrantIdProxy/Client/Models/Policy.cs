using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class Policy : IPolicy
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

        [DataMember(Name = "apiId", EmitDefaultValue = false)]
        public int? ApiId { get; }

        [DataMember(Name = "details", EmitDefaultValue = false)]
        public PolicyDetails Details { get; }

        [DataMember(Name = "enabled", EmitDefaultValue = false)]
        public PolicyEnabled Enabled { get; }

        [DataMember(Name = "organizationId", EmitDefaultValue = false)]
        public Guid? OrganizationId { get; }

        [DataMember(Name = "certificateAuthorityId", EmitDefaultValue = false)]
        public Guid? CertificateAuthorityId { get; }

    }
}