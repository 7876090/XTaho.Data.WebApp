using System.Data;
using System.Xml.Linq;
using XTaho.Data.WebApp.DataAccess.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace XTaho.Data.WebApp.Models.DataSets
{
    public class IdentityUserRolesDataSet
    {
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public string? RoleName{ get; set;}
        public bool IsActive { get; set; }

        public string? NormalizedName { get; set; }

        public IdentityUserRolesDataSet() { }

        public static string RecordsQueryText()
        {
            return "SELECT \"UserId\", \"RoleId\"\r\nFROM public.\"AspNetUserRoles\";";
        }

        public static string RecordsQueryText(string? userId)
        {
            return "SELECT \"Id\" as RoleId, \"Name\" as RoleName, \"NormalizedName\", userroles.checked as IsActive " +
                "FROM public.\"AspNetRoles\" left join(SELECT case when \"UserId\" is null then false else true end as checked, " +
                $"\"RoleId\" FROM public.\"AspNetUserRoles\" where \"UserId\" = '{userId}') as userRoles on \"Id\" = userRoles.\"RoleId\" " +
                $"where \"Id\" != '{DefaultRoles.Operator.Id}'";
        }
    }
}
