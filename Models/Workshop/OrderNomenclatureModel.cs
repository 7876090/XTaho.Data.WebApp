using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Workshop
{
    [DataTable("NCI_OrderNomenclature")]
    public class OrderNomenclatureModel : BaseModel
    {
        [DataTableColumn("NomenclatureId", WellknownDataTypes.INTEGER)]
        public int NomenclatureId { get; set; }
        public string? NomenclatureName { get; set; }
        public string? VendorCode { get; set; }
        [DataTableColumn("Count", WellknownDataTypes.INTEGER)]
        public int Count { get; set; }
        [DataTableColumn("Price", WellknownDataTypes.INTEGER)]
        public int Price { get; set; }
        public List<OrderNomenclatureModel>? Nomenclature { get; set; }
    }
}
