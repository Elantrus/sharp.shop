using Newtonsoft.Json;

namespace WebApi.Middlewares.Models;

public class RequestErrorBase
{
    public string Message { get; set; }
    public DateTime Ocurrence { get; set; }
    
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public string? StackTrace { get; set; }
}