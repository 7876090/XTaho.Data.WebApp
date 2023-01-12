using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_DeviceModels")]
    public class DeviceModelsModel : CatalogModel
    {
        [DataTableColumn("Number", WellknownDataTypes.INTEGER)]
        public int Number { get; set; }

        [DataTableColumn("RegistrationNumber", WellknownDataTypes.INTEGER)]
        public int RegistrationNumber { get; set; }


        public DeviceModelsModel() 
        {
            CreatedDate = DateTime.Now;
        }
    }
}
