namespace XTaho.Data.WebApp.Models.Workshop.Schedule
{
    public class WeekDescription
    {
        public List<DayDescription>? DayDescriptions { get; set; }

        public WeekDescription()
        {
            DayDescriptions = new List<DayDescription>();
        }
    }
}
