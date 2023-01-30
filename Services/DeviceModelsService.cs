using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Catalogs;
using Microsoft.AspNetCore.Authorization;

namespace XTaho.Data.WebApp.Services
{
    public class DeviceModelsService
    {
        public async Task<QueryResult<DeviceModelsModel>> GetDeviceModelsListAsync()
        {
            DeviceModelsModel model = new DeviceModelsModel();
            string qText = model.RecordsQueryText<DeviceModelsModel>();
            return await Connector.GetRecordsAsync<DeviceModelsModel>(qText);
        }

        public async Task<ExecuteResult> AddModelAsync(DeviceModelsModel model)
        {
            string qText = model.AddRecordQueryText<DeviceModelsModel>();
            return await Connector.AddRecordAsync<DeviceModelsModel>(qText, model);
        }

        public async Task<ExecuteResult> UpdateModelAsync(DeviceModelsModel model)
        {
            string qText = model.UpdateRecordQueryText<DeviceModelsModel>();
            return await Connector.UpdateRecordAsync<DeviceModelsModel>(qText, model);
        }
    }
}