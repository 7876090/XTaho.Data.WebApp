using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.DataAccess.Identity;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_Devices")]
    public class DeviceModel : CatalogModel
    {
        [DataTableColumn("SerialNumber", WellknownDataTypes.VARCHAR_15)]
        public string? SerialNumber { get; set; }

        [DataTableColumn("FirmwareVersion", WellknownDataTypes.VARCHAR_15)]
        public string? FirmwareVersion { get; set; }

        [DataTableColumn("FirmwareUpdateDate", WellknownDataTypes.DATE)]
        public DateTime? FirmwareUpdateDate { get; set; }

        [DataTableColumn("FilesMask", WellknownDataTypes.TEXT)]
        public string? FilesMask { get; set; }

        [DataTableColumn("ModelId", WellknownDataTypes.INTEGER)]
        public int ModelId { get; set; }

        [DataTableColumn("VehicleRegistrationNumber", WellknownDataTypes.VARCHAR_15)]
        public string VehicleRegistrationNumber { get; set; }

        [DataTableColumn("MemberId", WellknownDataTypes.INTEGER)]
        public int MemberId { get; set; }

        public string? ModelName { get; set; }
        public string? MemberName { get; set; }
        public string? VIN { get; set; }


        public DeviceModel() 
        {
            CreatedDate = DateTime.Now;
            VehicleRegistrationNumber = string.Empty;            
        }

        public string RecordsQueryText()
        {
            return "SELECT devices.serialnumber, devices.firmwareversion, devices.firmwareupdatedate, devices.filesmask, devices.modelid, devices.name," +
                "devices.description, devices.id, devices.createddate, devices.isdeleted, devices.vehicleregistrationnumber, devices.memberid, models.name as ModelName" +
                ",members.name as membername " +
                "FROM nsi_devices as devices " +
                "left join nsi_devicemodels as models on devices.modelid = models.id " +
                "left join nsi_members as members on devices.memberid  = members.id  ORDER BY id ASC";
        }
    }
}
