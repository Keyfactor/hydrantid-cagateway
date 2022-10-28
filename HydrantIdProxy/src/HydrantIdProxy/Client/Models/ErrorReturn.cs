using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class ErrorReturn : IErrorReturn
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)] public string Status { get; set; }
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)] public string Error { get; set; }
    }
}
