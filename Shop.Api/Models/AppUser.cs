using Microsoft.AspNetCore.Identity;

namespace Shop.Api.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}