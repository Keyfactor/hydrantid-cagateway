using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Keyfactor.HydrantId.Client.Models.Enums;
using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models
{
    [DataContract]
    public class CertRequestStatus : ICertRequestStatus
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevocationStatusEnum
        {
            [EnumMember(Value = "VALID")] Valid = 1,

            [EnumMember(Value = "PENDING")] Pending = 2,

            [EnumMember(Value = "IN_PROCESS")] InProcess = 3,

            [EnumMember(Value = "REVOKED")] Revoked = 4,

            [EnumMember(Value = "FAILED")] Failed = 5
        }

        [DataMember(Name = "revocationStatus", EmitDefaultValue = false)]
        public RevocationStatusEnum? RevocationStatus { get; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; }

        [DataMember(Name = "issuanceStatus", EmitDefaultValue = false)]
        public IssuanceStatus IssuanceStatus { get; }

        [DataMember(Name = "issuanceStatusDetails", EmitDefaultValue = false)]
        public Dictionary<string, object> IssuanceStatusDetails { get; }

        [DataMember(Name = "certificateId", EmitDefaultValue = false)]
        public Guid? CertificateId { get; }
    }
}