using Humanizer;
using System.Collections.Generic;
using XTaho.Data.WebApp.Collections.PostgreSql;
using XTaho.Data.WebApp.Models.BaseModels;
using XTaho.Data.WebApp.Models.DataSets;


namespace XTaho.Data.WebApp.Models.Access
{
    [DataTable("NSI_MembersUsers")]
    public class MembersUsersModel : CatalogModel
    {
        [DataTableColumn("UserId", WellknownDataTypes.TEXT)]
        public string? UserId { get; set; }

        [DataTableColumn("MemberId", WellknownDataTypes.INTEGER)]
        public int MemberId { get; set; }

        [DataTableColumn("ISActive", WellknownDataTypes.BOOL_NOT_NULL_DEF_F)]
        public bool IsActive { get; set; }

        public string? UserName { get; set; }
        public string? MemberName { get; set; }


        public MembersUsersModel() 
        {
            Name = "";
            CreatedDate = DateTime.Now;
        }

        public static string RecordsQueryText()
        {
            return "SELECT userid, memberid, isactive, membersusers.name as name, membersusers.description, membersusers.id, membersusers.createddate, membersusers.isdeleted, members.name as membername, users.\"UserName\" as username " +
                "FROM nsi_membersusers as membersusers " +
                "left join nsi_members as members on membersusers.memberid=members.id " +
                "left join \"AspNetUsers\" as users on membersusers.userid=users.\"Id\";";
        }

        public static string RecordsQueryText(string userId)
        {
            return "select * from nsi_members nm " +
                $"where id in (select memberid as id FROM public.nsi_membersusers WHERE userid = '{userId}');";
        }

        public static string RecordsQueryTextForOperator()
        {
            return "SELECT * " +
                "FROM public.nsi_members;";
        }

        public static string AddRolesListQueryText(string? userId, List<IdentityUserRolesDataSet> roles)
        {
            List<string> queryText = new List<string>();

            foreach (var item in roles)
            {
                if (item.IsActive)
                {
                    queryText.Add($"INSERT INTO public.\"AspNetUserRoles\"(\"UserId\", \"RoleId\") VALUES('{userId}', '{item.RoleId}');");
                }
            }

            return string.Join("", queryText);
        }
    }
}
