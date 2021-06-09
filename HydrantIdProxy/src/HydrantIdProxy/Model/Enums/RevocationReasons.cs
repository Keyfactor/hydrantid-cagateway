using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Keyfactor.HydrantId.Model.Enums
{
    /// <summary>
    ///     reason:  * &#x60;1&#x60; - Key Compromise  * &#x60;3&#x60; - Affiliation Changed  * &#x60;4&#x60; - Superseded  *
    ///     &#x60;5&#x60; - Cessation of Operation
    /// </summary>
    /// <value>
    ///     reason:  * &#x60;1&#x60; - Key Compromise  * &#x60;3&#x60; - Affiliation Changed  * &#x60;4&#x60; - Superseded
    ///     * &#x60;5&#x60; - Cessation of Operation
    /// </value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RevocationReasons
    {
        /// <summary>
        ///     Enum NUMBER_1 for value: 1
        /// </summary>
        [EnumMember(Value = "1")] KeyCompromise = 1,

        /// <summary>
        ///     Enum NUMBER_3 for value: 3
        /// </summary>
        [EnumMember(Value = "3")] AffiliationChanged = 3,

        /// <summary>
        ///     Enum NUMBER_4 for value: 4
        /// </summary>
        [EnumMember(Value = "4")] Superseded = 4,

        /// <summary>
        ///     Enum NUMBER_5 for value: 5
        /// </summary>
        [EnumMember(Value = "5")] CessationOfOperation = 5
    }
}