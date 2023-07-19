using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class DeviceSnapshot
    {
        [JsonProperty("tachograph")]
        public DeviceInfo? DeviceInfo { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("details")]
        public DeviceSnapshotDetails? Details { get; set; }
    }
}
