using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class HawkCredential : IHawkCredential
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; }

        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; }

        [DataMember(Name = "lastUsed", EmitDefaultValue = false)]
        public DateTime? LastUsed { get; }

        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime? CreatedAt { get; }

        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public DateTime? UpdatedAt { get; }

    }
}