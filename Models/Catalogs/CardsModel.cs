using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_Cards")]
    public class CardsModel : CatalogModel
    {
        [DataTableColumn("SerialNumber", WellknownDataTypes.BIGINT)]
        public long SerialNumber { get; set; }

        [DataTableColumn("PrintNumber", WellknownDataTypes.VARCHAR_50)]
        public string? PrintNumber { get; set; }

        public int OwnerId { get; set; }


        public CardsModel() 
        {
            CreatedDate= DateTime.Now;
        }
    }
}
