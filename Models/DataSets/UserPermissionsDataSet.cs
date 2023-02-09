using XTaho.Data.WebApp.Models.Catalogs;
using XTaho.Data.WebApp.Models.Access;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace XTaho.Data.WebApp.Models.DataSets
{
    public class UserPermissionsDataSet
    {
        private UserManager<IdentityUser> userManager;
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        private List<MemberModel> memberModels;

        public List<MemberModel> Members {
            get
            {
                return memberModels;
            }
        }

        public async void Init()
        {
            memberModels = new List<MemberModel>();

            var user = (await authenticationStateTask).User;
            if (user.Identity.IsAuthenticated)
            {
                var currenUser = await userManager.GetUserAsync(user);            
                if(user.IsInRole("Operator"))
                {
                    // получить все организации
                    string qText = MembersUsersModel.RecordsQueryTextForOperator();
                    // установить все разрешения

                }
                else
                {
                    string qText = MembersUsersModel.RecordsQueryText(currenUser.Id);
                }
            }
        }

    }
}
