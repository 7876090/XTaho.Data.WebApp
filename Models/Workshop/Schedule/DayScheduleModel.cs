using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;

namespace XTaho.Data.WebApp.Models.Workshop.Schedule
{
    [DataTable("NSI_Schedule")]
    public class DayScheduleModel : BaseModel
    {
        [DataTableColumn("ScheduleDate", WellknownDataTypes.DATE)]
        public DateTime ScheduleDate { get; set; }

        [DataTableColumn("MemberId", WellknownDataTypes.INTEGER)]
        public int MemberId { get; set; }
        [DataTableColumn("Description", WellknownDataTypes.TEXT)]
        public string? Description { get; set; }
    }
}
