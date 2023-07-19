using System.Net;
using System.Text.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class SnapshotResult
    {
        public bool Result { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public DeviceSnapshot? DeviceSnapshot { get; set; }

        public ServerError? ServerError { get; set; }

        public SnapshotResult(bool result, HttpStatusCode httpStatusCode) 
        { 
            Result = result;
            StatusCode = httpStatusCode;
        }

        public SnapshotResult(bool result, string? deviceSnapshot, string serverError) 
        {
            Result = result;
            StatusCode = HttpStatusCode.OK;
            if (!string.IsNullOrEmpty(deviceSnapshot))
            {
                DeviceSnapshot = JsonSerializer.Deserialize<DeviceSnapshot>(deviceSnapshot);
            }
            if (!string.IsNullOrEmpty(serverError))
            {
                ServerError = JsonSerializer.Deserialize<ServerError>(serverError);
                StatusCode = HttpStatusCode.Conflict;
            }
        }
    }
}
