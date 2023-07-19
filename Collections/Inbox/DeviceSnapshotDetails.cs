using Newtonsoft.Json;
using System.Text.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class DeviceSnapshotDetails
    {
        [JsonProperty("lastStateDate")]
        public DateTimeOffset LastStateDate { get; set; }

        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("gosNumber")]
        public string? GosNumber { get; set; }

        [JsonProperty("serialNumber")]
        public Int64 SerialNumber { get; set; }

        [JsonProperty("serialNumberDec")]
        public string? SerialNumberDec { get; set; }

        [JsonProperty("nkm")]
        public string? NKM { get; set; }

        [JsonProperty("speed")]
        public Int32 Speed { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("lastValidCoordinateTime")]
        public DateTimeOffset LastValidCoordinateTime { get; set; }

        [JsonProperty("isCoordsValuesOutdated")]
        public bool IsCoordsValuesOutdated { get; set; }

        [JsonProperty("taxoSendValidCoordsInLastPackage")]
        public bool TaxoSendValidCoordsInLastPackage { get; set; }

        [JsonProperty("driverName")]
        public string? DriverName { get; set; }

        [JsonProperty("modeAlert")]
        public bool ModeAlert { get; set; }

        [JsonProperty("isDriverCardInsideSlot1")]
        public bool IsDriverCardInsideSlot1 { get; set; }

        [JsonProperty("isDriverCardInsideSlot2")]
        public bool IsDriverCardInsideSlot2 { get; set; }

        [JsonProperty("workMode")]
        public string? WorkMode { get; set; }

        [JsonProperty("startSensorDate")]
        public DateTimeOffset StartSensorDate { get; set; }

        [JsonProperty("sensors")]
        public List<string>? Sensors { get; set; }

    }
}
