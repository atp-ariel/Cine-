using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.Identity;
using Microsoft.AspNetCore.Identity;

namespace ServiceLayer.Identity
{
    public interface IUserStore
    {
        UserManager<AppUser> Users { get;  }


        Task<IdentityResult> SignUp(SignUpModel model, string role);
        Task<IdentityResult> RemoveUser(string username);
        Task<IEnumerable<AppUser>> GetUsers(string role);
        Task<AppUser> FindByUsername(string username);

        Task<string> GetClaimAsync(string username, string claim);
        Task<IdentityResult> SetClaimAsync(string username, string claim, string value);
        Task<IdentityResult> RemoveClaimAsync(string username, string claim);
        Task<IdentityResult> PromoteAsync(string username, string role);

    }
}
