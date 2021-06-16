using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestPolicy : ICertRequestPolicy
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

    }
}