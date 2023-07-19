using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class DeviceSnapshotResult
    {
        [JsonProperty("exists")]
        public bool Exists { get; set; }

        [JsonProperty("result")]
        public DeviceSnapshot? DeviceSnapshot { get; set; }
    }
}
