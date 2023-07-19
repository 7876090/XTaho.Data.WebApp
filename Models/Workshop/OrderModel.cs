using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Workshop
{
    [DataTable("NSI_Orders")]
    public class OrderModel : BaseModel
    {
        [DataTableColumn("MemberId", WellknownDataTypes.INTEGER)]
        public int MemberId { get; set; }
        [DataTableColumn("Description", WellknownDataTypes.TEXT)]
        public string? Description { get; set; }
        [DataTableColumn("StatusId", WellknownDataTypes.INTEGER)]
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
        public string? MemberName { get; set; }
    }
}
