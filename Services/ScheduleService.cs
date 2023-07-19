using Microsoft.AspNetCore.Identity;
using XTaho.Data.WebApp.DataAccess.Identity;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Workshop.Schedule;

namespace XTaho.Data.WebApp.Services
{
    public class ScheduleService
    {
        public async Task<QueryResult<DayScheduleModel>> GetShedule(DateTime day)
        {
            string qText = "SELECT scheduledate, description, id, createddate, isdeleted " +
                "FROM public.nsi_schedule " +
                $"where scheduledate between '{day.Year}-{day.Month}-{day.Day}' and '{day.Year}-{day.Month}-{day.Day}';";

            return await Connector.GetRecordsAsync<DayScheduleModel>(qText);
        }
        public async Task<QueryResult<DayScheduleModel>> GetShedule(int memberId, DateTime startDay, DateTime endDay)
        {
            string qText = "SELECT scheduledate, description, id, createddate, isdeleted " +
                "FROM public.nsi_schedule " +
                $"where memberid = {memberId} and (scheduledate between '{startDay.Year}-{startDay.Month}-{startDay.Day}' and '{endDay.Year}-{endDay.Month}-{endDay.Day}');";

            return await Connector.GetRecordsAsync<DayScheduleModel>(qText);
        }

        public async Task<ExecuteResult> AddDayScheduleAsync(DayDescription dayDescription, DayScheduleModel dayScheduleModel, int memberID)
        {
            string qText = "INSERT INTO public.nsi_schedule\r\n(scheduledate, description, createddate, isdeleted, memberid)\r\n" +
                $"VALUES('{dayDescription.Date.Year}-{dayDescription.Date.Month}-{dayDescription.Date.Day}', '{dayScheduleModel.Description}', now(), false, {memberID});\r\n";
            return await Connector.ExecuteAsync(qText);
        }
        public async Task<ExecuteResult> UpdateDayScheduleAsync(DayDescription dayDescription, DayScheduleModel dayScheduleModel)
        {
            string qText = $"UPDATE public.nsi_schedule\r\nSET description='{dayScheduleModel.Description}', isdeleted={dayScheduleModel.IsDeleted} " +
                $"WHERE id={dayScheduleModel.Id};";
            return await Connector.ExecuteAsync(qText);
        }
    }
}
