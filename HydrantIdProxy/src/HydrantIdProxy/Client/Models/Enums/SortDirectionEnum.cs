using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Client.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortDirectionEnum
    {
        [EnumMember(Value = "asc")] Asc = 1,
        [EnumMember(Value = "desc")] Desc = 2
    }
}