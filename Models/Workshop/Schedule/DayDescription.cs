using System;

namespace XTaho.Data.WebApp.Models.Workshop.Schedule
{
    public class DayDescription
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Number { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public List<DayScheduleModel> Schedule { get; set; }
        public DayDescription()
        {
            Name = string.Empty;
            ShortName = string.Empty;
            Number = 0;
            Schedule = new List<DayScheduleModel>();
        }

        public DayDescription(int year, int month, int day)
        {
            Date = new DateTime(year, month, day);
            DayOfWeek = Date.DayOfWeek;

            Name = "Воскресенье";
            ShortName = "ВС";
            Number = 7;
            Schedule = new List<DayScheduleModel>();

            switch (DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Name = "Понедельник";
                    ShortName = "ПН";
                    Number = 1;
                    break;
                case DayOfWeek.Tuesday:
                    Name = "Вторник";
                    ShortName = "ВТ";
                    Number = 2;
                    break;
                case DayOfWeek.Wednesday:
                    Name = "Среда";
                    ShortName = "СР";
                    Number = 3;
                    break;
                case DayOfWeek.Thursday:
                    Name = "Четверг";
                    ShortName = "ЧТ";
                    Number = 4;
                    break;
                case DayOfWeek.Friday:
                    Name = "Пятница";
                    ShortName = "ПТ";
                    Number = 5;
                    break;
                case DayOfWeek.Saturday:
                    Name = "Суббота";
                    ShortName = "СБ";
                    Number = 6;
                    break;
            }
        }
    }
}
