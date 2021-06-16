using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class RevokeCertificateReasonIssuerDn : IRevokeCertificateReasonIssuerDn
    {
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public RevocationReasons Reason { get; }

        [DataMember(Name = "issuerDN", EmitDefaultValue = false)]
        public string IssuerDn { get; }

    }
}