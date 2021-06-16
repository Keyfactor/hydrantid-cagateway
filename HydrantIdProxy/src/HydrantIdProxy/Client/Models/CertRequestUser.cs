using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestUser : ICertRequestUser
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; }

        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; }

    }
}