using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Reflection;
using XTaho.Data.WebApp.Models.BaseModels;
using XTaho.Data.WebApp.Collections;
using XTaho.Data.WebApp.DataAccess.Identity;
using XTaho.Data.WebApp.DataAccess.PostgreSql;
using XTaho.Data.WebApp.Models.Access;
using static Humanizer.In;
using XTaho.Data.WebApp.Models.DataSets;

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

        public async Task<QueryResult<CRUD>> GetCRUDPermissionsAsync(string roleId)
        {
            string qText = CRUD.RecordsQueryText(roleId);
            return await Connector.GetRecordsAsync<CRUD>(qText);
        }

        public async Task<ExecuteResult> AddCRUDPermissionsAsync(List<CRUD> permissions, string roleId)
        {
            List<string> qList = new List<string>();
            foreach (var item in permissions)
            {
                qList.Add($"INSERT INTO public.nsi_crud (roleid, modelname, cancreate, canread, canupdate, candelete, createddate)" +
                    $"VALUES('{roleId}', '{item.ModelName}', '{item.CanCreate}', '{item.CanRead}', '{item.CanUpdate}', '{item.CanDelete}', '{DateTime.Now}');");
            }
            string qText = string.Join("", qList);

            return await Connector.ExecuteAsync(qText);
        }

        public async Task<ExecuteResult> UpdateCRUDPermissionsAsync(List<CRUD> permissions, string roleId)
        {
            List<string> qList = new List<string>();
            foreach (var item in permissions)
            {
                qList.Add($"UPDATE public.nsi_crud " +
                    $"SET roleid='{roleId}', modelname='{item.ModelName}', cancreate='{item.CanCreate}', canread='{item.CanRead}', canupdate='{item.CanUpdate}', candelete='{item.CanDelete}' " +
                    $"WHERE roleid = '{roleId}' AND modelname='{item.ModelName}';");
            }
            string qText = string.Join("", qList);

            return await Connector.ExecuteAsync(qText);
        }

        public async Task<QueryResult<IdentityUserRolesDataSet>> GetRolesListAsync(string userId)
        {
            string qText = IdentityUserRolesDataSet.RecordsQueryText(userId);
            return await Connector.GetRecordsAsync<IdentityUserRolesDataSet>(qText);
        }

        public async Task <ExecuteResult> UpdateRolesListAsync(string? userId, List<IdentityUserRolesDataSet> roles)
        {
            List<string> queryText = new List<string>();
            queryText.Add($"DELETE FROM public.\"AspNetUserRoles\"\r\nWHERE \"UserId\"='{userId}';");

            foreach (var item in roles)
            {
                if (item.IsActive)
                {
                    queryText.Add($"INSERT INTO public.\"AspNetUserRoles\"(\"UserId\", \"RoleId\") VALUES('{userId}', '{item.RoleId}');");
                }
            }

            string qText = string.Join("", queryText);

            return await Connector.ExecuteAsync(qText);
        }

    }
}
