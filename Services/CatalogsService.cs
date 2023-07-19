using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Catalogs;
using XTaho.Data.WebApp.Models.Workshop;

namespace XTaho.Data.WebApp.Services
{
    public class CatalogsService
    {
        public async Task<QueryResult<OrderStatusesModel>> GetOrderStatusesListAsync()
        {
            OrderModel order = new OrderModel();
            string qText = "SELECT \"name\", description, id, createddate, isdeleted FROM public.nsi_orderstatuses;";

            return await Connector.GetRecordsAsync<OrderStatusesModel>(qText);
        }
    }
}
