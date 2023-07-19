using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class ServerDescription
    {
        [JsonProperty("productId")]
        public string? ProductId { get; set; }

        [JsonProperty("productVersion")]
        public string? ProductVersion { get; set; }

        [JsonProperty("productBuildVersion")]
        public string? ProductBuildVersion { get; set; }

        [JsonProperty("installationName")]
        public string? InstallationName { get; set;}

        [JsonProperty("installationId")]
        public string? InstallationId { get; set; }

        [JsonProperty("dateTime")]
        public DateTime? DateTime { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, string>? Properties { get; set; }
    }
}
