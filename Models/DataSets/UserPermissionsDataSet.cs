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
        private UserManager<IdentityUser> userManager;
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        private List<MemberModel> members;

        public List<MemberModel> Members {
            get
            {
                return members;
            }
        }

        public string MembersString { 
            get
            {
                return string.Join(",", members);
            }
        }

        public async void Init()
        {
            members = new List<MemberModel>();

            var user = (await authenticationStateTask).User;
            if (user.Identity.IsAuthenticated)
            {
                string qText = "";
                var currenUser = await userManager.GetUserAsync(user);            
                if(user.IsInRole("Operator"))
                {
                    qText = MembersUsersModel.RecordsQueryTextForOperator();
                }
                else
                {
                    qText = MembersUsersModel.RecordsQueryText(currenUser.Id);
                }
                QueryResult<MemberModel> members = await Connector.GetRecordsAsync<MemberModel>(qText);
            }
        }

    }
}
