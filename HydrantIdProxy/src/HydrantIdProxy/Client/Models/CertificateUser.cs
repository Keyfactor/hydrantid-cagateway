using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertificateUser : ICertificateUser
    {

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; }


    }
}