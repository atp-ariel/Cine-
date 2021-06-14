using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Identity 
{
    public class AppUser : IdentityUser
    {
        public string Address {get; set;}
    }
}