using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Catalogs
{
    [DataTable("NSI_Members")]
    public class MemberModel : CatalogModel
    {
        [DataTableColumn("inn", WellknownDataTypes.VARCHAR_15)]
        [Required]
        [StringLength(13, ErrorMessage = "ИНН не может быть больше 13 знаков!")]
        public string? INN { get; set; }

        public MemberModel()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
