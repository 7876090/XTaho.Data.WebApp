using System.Xml.Linq;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Catalogs;
using XTaho.Data.WebApp.Models.Workshop;
using static NuGet.Packaging.PackagingConstants;

namespace XTaho.Data.WebApp.Services
{
    public class OrderService
    {
        public async Task<QueryResult<OrderModel>> GetOrdersListAsync(string members)
        {
            OrderModel order = new OrderModel();
            string qText = $"select orders.memberid as memberid, orders.description, orders.id, orders.createddate, orders.isdeleted, members.\"name\" as membername, statuses.Name as statusname " +
                "from public.nsi_orders as orders " +
                "left join public.nsi_members as members on orders.memberid = members.id " +
                "left join public.nsi_orderstatuses as statuses on orders.statusid = statuses.id " +
                $"where memberid in ({members}) and members.id in ({members});";

            return await Connector.GetRecordsAsync<OrderModel>(qText);
        }

        public async Task<ExecuteResult> AddOrderAsync(OrderModel order)
        {
            string qText = "";
            return await Connector.AddRecordAsync<OrderModel>(qText, order);
        }

        public async Task<ExecuteResult> UpdateOrderAsync(OrderModel order)
        {
            string qText = "";
            return await Connector.UpdateRecordAsync<OrderModel>(qText, order);
        }
    }
}
