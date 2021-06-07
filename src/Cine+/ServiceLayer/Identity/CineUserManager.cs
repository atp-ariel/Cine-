using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DomainLayer.Identity;

namespace ServiceLayer.Identity
{
    public partial class CineUserManager
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        internal UserManager<IdentityUser> UserManager => _userManager;
        internal SignInManager<IdentityUser> SignInManager => _signInManager;
        
        public CineUserManager(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        /// <summary>
        /// Searches the user manager for a user given his username
        /// </summary>
        /// <param name="username">The username given</param>
        /// <returns></returns>
        public async Task<IdentityUser> FindByUsername(string username)
        {
            // * Search on UserManager by username
            return await UserManager.FindByNameAsync(username);
        } 

        public async Task<IdentityResult> CreateUserAsync(SignUpModel model){
            // * Create an user instance
            IdentityUser user = new IdentityUser{
                        Email = model.Email,
                        UserName = model.Username
                    };
            // * Save on user manager
            return await UserManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> Login(SignInModel model)
        {
            return await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        }
    }
}
