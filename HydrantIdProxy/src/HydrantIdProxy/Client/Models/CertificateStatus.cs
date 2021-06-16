using System;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertificateStatus : ICertificateStatus
    {

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; }

        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum RevocationStatus { get; }

        [DataMember(Name = "revocationReason", EmitDefaultValue = false)]
        public RevocationReasons RevocationReason { get; }

        [DataMember(Name = "revocationDate", EmitDefaultValue = false)]
        public DateTime? RevocationDate { get; }

    }
}