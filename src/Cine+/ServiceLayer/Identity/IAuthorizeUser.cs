using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Identity;

namespace ServiceLayer.Identity
{
    public interface IAuthorizeUser
    {
        SignInManager<AppUser> SignInManager { get; }

        Task<SignInResult> Login(SignInModel model);
        void Logout();
    }
}
