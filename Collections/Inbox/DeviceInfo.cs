using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class DeviceInfo
    {
        [JsonProperty("id")]
        public Int64 Id { get; set; }

        [JsonProperty("createDate")]
        public DateTimeOffset CreateDate { get; set; }

        [JsonProperty("serialNumber")]
        public Int64 SerialNumber { get; set; }
    }
}
