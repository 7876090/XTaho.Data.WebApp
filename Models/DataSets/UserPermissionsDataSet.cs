using XTaho.Data.WebApp.Models.Catalogs;
using XTaho.Data.WebApp.Models.Access;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Services;

namespace XTaho.Data.WebApp.Models.DataSets
{
    public class UserPermissionsDataSet
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        private List<MemberModel> members;
        private List<CRUD> crud;

        public List<MemberModel> Members { get { return members; } }

        public string MembersString { 
            get
            {
                var membersString = "";
                if (members != null)
                {
                    if (members.Count() > 0)
                    {
                        foreach (var member in members)
                        {
                            membersString = membersString + $"{member.Id},";
                        }
                        membersString = membersString.Substring(0, membersString.Length - 1);
                    }
                    else
                    {
                        membersString = "-1";
                    }
                }
                else
                {
                    membersString = "-1";
                }
                return membersString;
            }
        }

        public List<CRUD> CRUDs { get { return crud; } }

        public async Task<ExecuteResult> Init(IdentityUser currentUser, bool isOperator)
        {
            members = new List<MemberModel>();
            crud = new List<CRUD>();
            ExecuteResult result = new ExecuteResult();
            string qText = "";
            string qTextCRUD = "";
            if (isOperator)
            {
                qText = MembersUsersModel.RecordsQueryTextForOperator();
                qTextCRUD = CRUD.RecordsQueryTextForOperator();
            }
            else
            {
                qText = MembersUsersModel.RecordsQueryText(currentUser.Id);
                qTextCRUD = CRUD.RecordsQueryTextByUserId(currentUser.Id);
            }
            QueryResult<MemberModel> membersResult = await Connector.GetRecordsAsync<MemberModel>(qText);
            if (membersResult.Success)
            {
                members = membersResult.Collection ?? new List<MemberModel>();
            }
            else
            {
                result = new ExecuteResult(membersResult.ErrorDescription ?? "Ошибка получения данных по доступным организациям!");
            }
            if (result.Success)
            {
                QueryResult<CRUD> crudResult = await Connector.GetRecordsAsync<CRUD>(qTextCRUD);
                if (crudResult.Success)
                {
                    crud = crudResult.Collection ?? new List<CRUD>();
                }
                else
                {
                    result = new ExecuteResult(crudResult.ErrorDescription ?? "Ошибка получения данных по доступным действиям!");
                }
            }

            return result;
        }

    }
}
