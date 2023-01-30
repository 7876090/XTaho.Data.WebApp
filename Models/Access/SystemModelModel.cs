using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Access
{
    [DataTable("NSI_SystemModels")]
    public class SystemModelModel : BaseModel
    {
        [DataTableColumn("Name", WellknownDataTypes.TEXT)]
        public string? Name { get; set; }
    }
}
