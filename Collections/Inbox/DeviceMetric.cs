using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class DeviceMetric
    {
        [JsonProperty("tag")]
        public string? Tag { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("valueType")]
        public string? ValueType { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("createDate")]
        public DateTimeOffset? CreateDate { get; set; }
    }
}
