using XTaho.Data.WebApp.DataAccess.Identity;

namespace XTaho.Data.WebApp.Models.DataSets
{
    public class IdentityUserDataSet
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }


        public IdentityUserDataSet() { }

        public static string RecordsQueryText()
        {
            return "SELECT users.\"Id\" , users.\"UserName\", users.\"Email\" " +
                "FROM public.\"AspNetUsers\" as users " +
                $"WHERE users.\"Id\" != '{DefaultUsers.Operator.Id}'";
        }
    }

}
