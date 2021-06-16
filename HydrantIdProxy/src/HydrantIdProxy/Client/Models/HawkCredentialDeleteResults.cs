using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class HawkCredentialDeleteResults : IHawkCredentialDeleteResults
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        [DataMember(Name = "deleted", EmitDefaultValue = false)]
        public bool? Deleted { get; }

    }
}