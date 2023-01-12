using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_NKMManufacturers")]
    public class NKMManufacturersModel : CatalogModel
    {

        public NKMManufacturersModel() 
        {
            CreatedDate= DateTime.Now;
        }
    }
}
