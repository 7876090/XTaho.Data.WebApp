using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Reflection;
using XTaho.Data.WebApp.Models.BaseModels;
using XTaho.Data.WebApp.Collections;
using XTaho.Data.WebApp.DataAccess.Identity;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Access;

namespace XTaho.Data.WebApp.Services
{
    public class RolesService
    {
        public async Task<QueryResult<IdentityRole>> GetRolesListAsync()
        {
            string qText = "SELECT \"Id\", \"Name\", \"NormalizedName\", \"ConcurrencyStamp\"\r\n" +
                "FROM public.\"AspNetRoles\"\r\n" +
                $"WHERE \"Id\" != '{DefaultRoles.Operator.Id}';";
            return await Connector.GetRecordsAsync<IdentityRole>(qText);

        }

        public async Task<ExecuteResult> AddRoleAsync(IdentityRole identityRole)
        {
            string qText = "INSERT INTO public.\"AspNetRoles\"\r\n(\"Id\", \"Name\", \"NormalizedName\", \"ConcurrencyStamp\")\r\n" +
                $"VALUES('{identityRole.Id}', '{identityRole.Name}', '{identityRole.NormalizedName}', '{identityRole.ConcurrencyStamp}');";
            return await Connector.ExecuteAsync(qText);
        }

        public async Task<ExecuteResult> UpdateRoleAsync(IdentityRole identityRole)
        {
            string qText = "UPDATE public.\"AspNetRoles\"\r\n" +
                $"SET \"Name\"='{identityRole.Name}', \"NormalizedName\"='{identityRole.NormalizedName}', \"ConcurrencyStamp\"='{identityRole.ConcurrencyStamp}'\r\n" +
                $"WHERE \"Id\"='{identityRole.Id}';";
            return await Connector.ExecuteAsync(qText);
        }

        public async Task<QueryResult<CRUD>> GetCRUDPermissions(string roleId)
        {
            string qText = CRUD.RecordsQueryText(roleId);
            return await Connector.GetRecordsAsync<CRUD>(qText);
        }
    }
    
    

    
}
