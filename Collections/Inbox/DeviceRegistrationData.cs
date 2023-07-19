using Newtonsoft.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class DeviceRegistrationData
    {
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        public DeviceRegistrationData(string serialNumber)
        {
            SerialNumber = serialNumber;
        }
    }
}
