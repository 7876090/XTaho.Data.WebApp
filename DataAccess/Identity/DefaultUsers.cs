using Microsoft.AspNetCore.Identity;

namespace XTaho.Data.WebApp.DataAccess.Identity
{
    public class DefaultUsers
    { 
        public static IdentityUser Operator = new()
        {
            Id = "FFD46EE8-FA69-496B-9624-BF66F7D907B7".ToLower(),
            Email = "XTaho@shtrih-m.ru",
            EmailConfirmed = true,
            UserName = "XTaho@shtrih-m.ru"
        };
    }
}
