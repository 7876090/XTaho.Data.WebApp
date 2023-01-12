using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_NKM")]
    public class NKMModel : CatalogModel
    {
        [DataTableColumn("SerialNumber", WellknownDataTypes.VARCHAR_15_NOT_NULL)]
        public string SerialNumber { get; set; }

        [DataTableColumn("InventoryNumber", WellknownDataTypes.VARCHAR_15)]
        public string? InventoryNumber { get; set; }

        [DataTableColumn("ExpirationDate", WellknownDataTypes.TIMESTAMP_WITHOUT_TIME_ZONE)]
        public DateTime? Date { get; set; }

        [DataTableColumn("VerificationExpirationDate", WellknownDataTypes.TIMESTAMP_WITHOUT_TIME_ZONE)]
        public DateTime? VerificationExpirationDate { get; set; }

        [DataTableColumn("NKMManufacturerId", WellknownDataTypes.INTEGER)]
        public int NKMManufacturerId { get; set; }

        [DataTableColumn("FirmwareVersion", WellknownDataTypes.VARCHAR_15)]
        public string? FirmwareVersion { get; set; }

        [DataTableColumn("ManufactureDate", WellknownDataTypes.TIMESTAMP_WITHOUT_TIME_ZONE)]
        public DateTime ManufactureDate { get; set; }

        [DataTableColumn("GNSSFirmvareVirsion", WellknownDataTypes.VARCHAR_15)]
        public string? GNSSFirmvareVirsion { get; set; }

        [DataTableColumn("KSSerialNumber", WellknownDataTypes.VARCHAR_15)]
        public string? KSSerialNumber { get; set; }

        [DataTableColumn("MaxSpeed", WellknownDataTypes.INTEGER)]
        public int MaxSpeed { get; set; }

        [DataTableColumn("KW", WellknownDataTypes.INTEGER)]
        public int KW { get; set; }

        public NKMModel() 
        {
            SerialNumber = "";
            CreatedDate= DateTime.Now;
        }
    }
}
