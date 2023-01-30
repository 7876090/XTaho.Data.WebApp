using Microsoft.AspNetCore.Authorization;
using System.Data;
using XTaho.Data.WebApp.DataAccess.Identity;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Access;
using XTaho.Data.WebApp.Models.Catalogs;
using XTaho.Data.WebApp.Models.DataSets;

namespace XTaho.Data.WebApp.Services
{  
    public class MembersUsersService
    {
        public async Task<QueryResult<MembersUsersModel>> GetMembersUsersListAsync()
        {
            string qText = MembersUsersModel.RecordsQueryText();
            return await Connector.GetRecordsAsync<MembersUsersModel>(qText);
        }

        public async Task<QueryResult<IdentityUserDataSet>> GetUsersListAsync()
        {
            string qText = IdentityUserDataSet.RecordsQueryText();
            return await Connector.GetRecordsAsync<IdentityUserDataSet>(qText);
        }

        public async Task<QueryResult<IdentityUserRolesDataSet>> GetUserRolesListAsync(MembersUsersModel model)
        {
            string qText = IdentityUserRolesDataSet.RecordsQueryText(model.UserId);
            return await Connector.GetRecordsAsync<IdentityUserRolesDataSet>(qText);
        }

        public async Task<ExecuteResult> AddMemberUserAsync(MembersUsersModel model)
        {
            string qText = model.AddRecordQueryText<MembersUsersModel>();
            return await Connector.AddRecordAsync<MembersUsersModel>(qText, model);
        }

        public async Task<ExecuteResult> UpdateMemberUserAsync(MembersUsersModel model)
        {
            string qText = model.UpdateRecordQueryText<MembersUsersModel>();
            return await Connector.UpdateRecordAsync<MembersUsersModel>(qText, model);
        }

        public async Task<ExecuteResult> UpdateUserRolesAsync(MembersUsersModel model, List<IdentityUserRolesDataSet> roles)
        {
            string qText = $"DELETE FROM public.\"AspNetUserRoles\"\r\nWHERE \"UserId\"='{model.UserId}';";
            ExecuteResult result = await Connector.ExecuteAsync(qText);
            if(result.Success)
            {
                qText = MembersUsersModel.AddRolesListQueryText(model.UserId, roles);
                result = await Connector.ExecuteAsync(qText);
            }
            return result;
        }
    }
}
