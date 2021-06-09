using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Model.Enums
{
    /// <summary>
    ///     Defines SortDirectionEnum
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortDirectionEnum
    {
        /// <summary>
        ///     Enum Asc for value: asc
        /// </summary>
        [EnumMember(Value = "asc")] Asc = 1,

        /// <summary>
        ///     Enum Desc for value: desc
        /// </summary>
        [EnumMember(Value = "desc")] Desc = 2
    }
}