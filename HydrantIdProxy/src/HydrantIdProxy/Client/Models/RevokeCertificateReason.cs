using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class RevokeCertificateReason : IRevokeCertificateReason
    {
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public RevocationReasons Reason { get; }

    }
}