using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Model.Enums
{
    /// <summary>
    ///     Defines RevocationStatusEnum
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RevocationStatusEnum
    {
        /// <summary>
        ///     Enum VALID for value: VALID
        /// </summary>
        [EnumMember(Value = "VALID")] Valid = 1,

        /// <summary>
        ///     Enum PENDING for value: PENDING
        /// </summary>
        [EnumMember(Value = "PENDING")] Pending = 2,

        /// <summary>
        ///     Enum INPROCESS for value: IN_PROCESS
        /// </summary>
        [EnumMember(Value = "IN_PROCESS")] InProcess = 3,

        /// <summary>
        ///     Enum REVOKED for value: REVOKED
        /// </summary>
        [EnumMember(Value = "REVOKED")] Revoked = 4,

        /// <summary>
        ///     Enum FAILED for value: FAILED
        /// </summary>
        [EnumMember(Value = "FAILED")] Failed = 5,

        /// <summary>
        ///     Enum EXPIRED for value: EXPIRED
        /// </summary>
        [EnumMember(Value = "EXPIRED")] Expired = 6,

        /// <summary>
        ///     Enum RENEWED for value: RENEWED
        /// </summary>
        [EnumMember(Value = "RENEWED")] Renewed = 7
    }
}