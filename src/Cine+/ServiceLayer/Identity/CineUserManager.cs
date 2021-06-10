using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DomainLayer.Identity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;


namespace ServiceLayer.Identity
{
    public class CineUserManager : IAuthorizeUserManager, IUserManager
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        #endregion

        #region Properties
        internal UserManager<AppUser> UserManager => _userManager;
        internal SignInManager<AppUser> SignInManager => _signInManager;
        internal RoleManager<IdentityRole> RoleManager => _roleManager;
        #endregion

        #region Constructor
        public CineUserManager(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }
        #endregion

        #region Methods
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

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> SignUp(SignUpModel model, string role){
            // * Create an user instance
            AppUser user = new AppUser{
                        Email = model.Email,
                        UserName = model.Username,
                        PhoneNumber = model.Phone,
                        Address = model.Address
                    };
            // * Save on user manager
            await UserManager.CreateAsync(user, model.Password);

            return await UserManager.AddToRoleAsync(user, role);
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SignInResult> Login(SignInModel model)
        {
            return await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        }

        /// <summary>
        /// Logout the authorized user
        /// </summary>
        public async void Logout()
        {
            await SignInManager.SignOutAsync();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AppUser>> GetUsers(string role){
            return await UserManager.GetUsersInRoleAsync(role); 
        }
        #endregion
    }
}
