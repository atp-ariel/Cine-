using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DomainLayer.Identity;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Identity
{
    public partial class CineUserManager
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        internal UserManager<AppUser> UserManager => _userManager;
        internal SignInManager<AppUser> SignInManager => _signInManager;
        
        public CineUserManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        /// <summary>
        /// Searches the user manager for a user given his username
        /// </summary>
        /// <param name="username">The username given</param>
        /// <returns></returns>
        public async Task<AppUser> FindByUsername(string username)
        {
            // * Search on UserManager by username
            return await UserManager.FindByNameAsync(username);
        } 

        public async Task<IdentityResult> CreateUserAsync(SignUpModel model){
            // * Create an user instance
            AppUser user = new AppUser{
                        Email = model.Email,
                        UserName = model.Username,
                        PhoneNumber = model.Phone,
                        Address = model.Address
                    };
            // * Save on user manager
            return await UserManager.CreateAsync(user, model.Password);
        }

        public async Task<SignInResult> Login(SignInModel model)
        {
            return await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        }

        public  IEnumerable<AppUser> GetUsers(){
            return  _userManager.Users;
        }
    }
}
