using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Model.Enums
{
    /// <summary>
    ///     Defines IssuanceStatus
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IssuanceStatus
    {
        /// <summary>
        ///     Enum APPROVALREQUIRED for value: APPROVAL_REQUIRED
        /// </summary>
        [EnumMember(Value = "APPROVAL_REQUIRED")]
        ApprovalRequired = 1,

        /// <summary>
        ///     Enum CANCELLED for value: CANCELLED
        /// </summary>
        [EnumMember(Value = "CANCELLED")] Cancelled = 2,

        /// <summary>
        ///     Enum FAILED for value: FAILED
        /// </summary>
        [EnumMember(Value = "FAILED")] Failed = 3,

        /// <summary>
        ///     Enum INPROCESS for value: IN_PROCESS
        /// </summary>
        [EnumMember(Value = "IN_PROCESS")] InProcess = 4,

        /// <summary>
        ///     Enum ISSUED for value: ISSUED
        /// </summary>
        [EnumMember(Value = "ISSUED")] Issued = 5,

        /// <summary>
        ///     Enum PENDING for value: PENDING
        /// </summary>
        [EnumMember(Value = "PENDING")] Pending = 6,

        /// <summary>
        ///     Enum REJECTED for value: REJECTED
        /// </summary>
        [EnumMember(Value = "REJECTED")] Rejected = 7
    }
}