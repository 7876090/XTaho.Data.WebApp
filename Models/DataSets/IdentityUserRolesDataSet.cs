using System.Data;
using System.Xml.Linq;
using XTaho.Data.WebApp.DataAccess.Identity;

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
            return $"SELECT roles.\"Id\" as roleid, roles.\"Name\" as rolename, roles.\"NormalizedName\" as normalizedname, userroles.\"UserId\" is not null as isactive " +
                "FROM public.\"AspNetRoles\" as roles " +
                $"left join(select* from public.\"AspNetUserRoles\" where \"UserId\"='{userId}') as userroles on roles.\"Id\"=userroles.\"RoleId\"" +
                $"WHERE roles.\"Id\" != '{DefaultRoles.Operator.Id}'";
        }
    }
}
