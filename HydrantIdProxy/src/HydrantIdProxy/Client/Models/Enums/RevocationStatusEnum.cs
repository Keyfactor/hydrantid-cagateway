using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RevocationStatusEnum
    {
        [EnumMember(Value = "VALID")] Valid = 1,
        [EnumMember(Value = "PENDING")] Pending = 2,
        [EnumMember(Value = "IN_PROCESS")] InProcess = 3,
        [EnumMember(Value = "REVOKED")] Revoked = 4,
        [EnumMember(Value = "FAILED")] Failed = 5,
        [EnumMember(Value = "EXPIRED")] Expired = 6,
        [EnumMember(Value = "RENEWED")] Renewed = 7
    }
}