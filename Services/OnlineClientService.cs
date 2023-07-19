using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;
using XTaho.Data.WebApp.Collections.Inbox;

namespace XTaho.Data.WebApp.Services
{
    public class OnlineClientService
    {
        /// <summary>
        /// Инициализация клиента сервера
        /// </summary>
        /// <returns>HttpClient</returns>
        private HttpClient InitClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri($"http://10.14.240.18:9901")
            };

            return client;
        }

        /// <summary>
        /// Получить описание сервера
        /// </summary>
        /// <returns>ServerDescriptionResult</returns>
        public async Task<ServerDescriptionResult> GetServerDescription()
        {
            var result = new ServerDescriptionResult(false, HttpStatusCode.OK);
            string uri = "/description";

            var client = InitClient();
            var response = await client.GetAsync(uri);

            if ( response != null )
            {
                var httpContent = await response.Content.ReadAsStringAsync();
                if(response.StatusCode == HttpStatusCode.OK )
                {
                    result = new ServerDescriptionResult(true, httpContent, string.Empty);
                }
                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    result = new ServerDescriptionResult(true, string.Empty, httpContent);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                { 
                    result.StatusCode = HttpStatusCode.BadRequest;
                }
            }

            return result;
        }
        
        /// <summary>
        /// Проверка доступности сервера
        /// </summary>
        /// <returns>true, false</returns>
        public async Task<bool> CheckServerAvailability()
        {
            bool result = false;
            string uri = "/health";

            var client = InitClient();
            var response = await client.GetAsync(uri);

            if (response != null) 
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Регистрация устройства на сервере
        /// </summary>
        /// <param name="serialNumber">Серийный номер</param>
        /// <returns></returns>
        public async Task<bool> RegisterDevice(string serialNumber)
        {
            string uri = "/api/v1/inbox/registration/v2";

            var client = InitClient();

            DeviceRegistrationData deviceRegistrationData = new DeviceRegistrationData(serialNumber);
            string content  = JsonConvert.SerializeObject(deviceRegistrationData);

            HttpContent htttpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, htttpContent);

            var httpContent = await response.Content.ReadAsStringAsync();

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Получение снимка устройства
        /// </summary>
        /// <param name="serialNumber">Серийный номер</param>
        /// <returns>Необходимо создать класс для описания результата DeviceSnapshot</returns>
        public async Task<SnapshotResult> GetSnapshot(Int64 serialNumber)
        {
            var result = new SnapshotResult(false, HttpStatusCode.OK);
            string uri = $"/api/v1/inbox/snapshot/?serialnumber={serialNumber.ToString()}";

            var client = InitClient();            
            var response = await client.GetAsync(uri);

            if (response != null)
            {
                var httpContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = new SnapshotResult(true, httpContent, string.Empty);
                }
                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    result = new SnapshotResult(false, string.Empty, httpContent);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    result.StatusCode = HttpStatusCode.BadRequest;
                }
            }

            return result;
        }

    }
}

