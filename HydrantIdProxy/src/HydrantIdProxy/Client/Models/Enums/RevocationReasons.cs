using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RevocationReasons
    {
        [EnumMember(Value = "1")] KeyCompromise = 1,
        [EnumMember(Value = "3")] AffiliationChanged = 3,
        [EnumMember(Value = "4")] Superseded = 4,
        [EnumMember(Value = "5")] CessationOfOperation = 5
    }
}