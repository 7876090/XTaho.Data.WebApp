using System.Net;
using System.Text.Json;

namespace XTaho.Data.WebApp.Collections.Inbox
{
    public class ServerDescriptionResult
    {
        public static JsonSerializerOptions SerializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public bool Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ServerDescription? ServerDescription { get; set; }
        public ServerError? ServerError { get; set; }        

        public ServerDescriptionResult(bool result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }

        public ServerDescriptionResult(bool result, string? serverDescription, string? serverError)
        {
            Result = result;
            StatusCode = HttpStatusCode.OK;
            if(!string.IsNullOrEmpty(serverDescription))
            {
                ServerDescription = JsonSerializer.Deserialize<ServerDescription>(serverDescription, SerializeOptions); 
            }
            if(!string.IsNullOrEmpty(serverError))
            {
                ServerError = JsonSerializer.Deserialize<ServerError>(serverError);
                StatusCode = HttpStatusCode.Conflict;
            }
        }
    }
}
