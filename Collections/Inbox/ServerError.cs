using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class ServerError
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("details")]
        public string? Details { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("severity")]
        public int Severity { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, string>? Data { get; set; }
    }
}
