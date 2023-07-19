using XTaho.Data.WebApp.Models.BaseModels;
using XTaho.Data.WebApp.Collections.PostgreSql;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_Nomenclature")]
    public class NomenclatureModel : CatalogModel
    {
        [DataTableColumn("Price", WellknownDataTypes.INTEGER)]
        public int Price { get; set; }
        [DataTableColumn("VendorCode", WellknownDataTypes.VARCHAR_50)]
        public string? VendorCode { get; set; }
    }
}
