using Microsoft.AspNetCore.Authorization;
using System.Data;
using XTaho.Data.WebApp.DataAccess.Identity;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Catalogs;

namespace XTaho.Data.WebApp.Services
{ 

    public class MembersService
    {       
        public async Task<QueryResult<MemberModel>> GetMembersListAsync()
        {
            MemberModel member = new MemberModel();
            string qText = member.RecordsQueryText<MemberModel>();
            return await Connector.GetRecordsAsync<MemberModel>(qText);
        }

        public async Task<ExecuteResult> AddMemberAsync(MemberModel member)
        {
            string qText = member.AddRecordQueryText<MemberModel>();
            return await Connector.AddRecordAsync(qText, member);
        }

        public async Task<ExecuteResult> UpdateMemberAsync(MemberModel member)
        {
            string qText = member.UpdateRecordQueryText<MemberModel>();
            return await Connector.UpdateRecordAsync(qText, member);
        }
    }
}
