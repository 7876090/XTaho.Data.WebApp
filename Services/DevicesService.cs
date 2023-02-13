using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Catalogs;

namespace XTaho.Data.WebApp.Services
{
    public class DevicesService
    {
        public async Task<QueryResult<DeviceModel>> GetDevicesListAsync(string members)
        {
            DeviceModel device = new DeviceModel();
            string qText = device.RecordsQueryText(members);
            return await Connector.GetRecordsAsync<DeviceModel>(qText);
        }

        public async Task<ExecuteResult> AddDeviceAsync(DeviceModel device)
        {
            string qText = device.AddRecordQueryText<DeviceModel>();
            return await Connector.AddRecordAsync<DeviceModel>(qText, device);
        }

        public async Task<ExecuteResult> UpdateDeviceAsync(DeviceModel device)
        {
            string qText = device.UpdateRecordQueryText<DeviceModel>();
            return await Connector.UpdateRecordAsync<DeviceModel>(qText, device);
        }
    }
}
