using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IssuanceStatus
    {
        [EnumMember(Value = "APPROVAL_REQUIRED")]
        ApprovalRequired = 1,
        [EnumMember(Value = "CANCELLED")] Cancelled = 2,
        [EnumMember(Value = "FAILED")] Failed = 3,
        [EnumMember(Value = "IN_PROCESS")] InProcess = 4,
        [EnumMember(Value = "ISSUED")] Issued = 5,
        [EnumMember(Value = "PENDING")] Pending = 6,
        [EnumMember(Value = "REJECTED")] Rejected = 7
    }
}