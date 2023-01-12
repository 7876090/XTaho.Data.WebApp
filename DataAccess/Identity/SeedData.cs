using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using System.Xml.Linq;

namespace XTaho.Data.WebApp.DataAccess.Identity
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider provider)
        {
            var rolesManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var role = rolesManager.FindByIdAsync(DefaultRoles.Operator.Id).Result;
            if(role == null) 
            {
                var result = rolesManager.CreateAsync(DefaultRoles.Operator).Result;
                if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
            }
            
            var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();
            var user = userManager.FindByIdAsync(DefaultUsers.Operator.Id).Result;
            if (user == null)
            {
                var result = await userManager.CreateAsync(DefaultUsers.Operator, "YfxybLtymCGhbznyjuj13");
                if (result.Succeeded)
                {
                    var Operator = await userManager.FindByIdAsync(DefaultUsers.Operator.Id);
                    await userManager.AddToRoleAsync(Operator, DefaultRoles.Operator.Name);
                }
            }
        }
    }
}
