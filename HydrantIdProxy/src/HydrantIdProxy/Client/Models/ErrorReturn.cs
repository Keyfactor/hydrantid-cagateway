using Keyfactor.HydrantId.Interfaces;
using Newtonsoft.Json;

namespace Keyfactor.HydrantId.Client.Models
{
    public class ErrorReturn : IErrorReturn
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)] public int Status { get; set; }
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)] public string Error { get; set; }
    }
}
