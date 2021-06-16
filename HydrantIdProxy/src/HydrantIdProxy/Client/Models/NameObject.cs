using System.Runtime.Serialization;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class NameObject : INameObject
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

    }
}