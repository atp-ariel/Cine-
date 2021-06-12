using DomainLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceLayer.Identity
{
    public class CinemaUsersStore : IUserStore
    {

        #region Fields
        private readonly UserManager<AppUser> _userManager;
        #endregion

        #region Properties
        public UserManager<AppUser> Users => _userManager;
        #endregion

        #region Constructor
        public CinemaUsersStore(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IdentityResult> SignUp(SignUpModel model, string role)
        {
            // * Create an user instance
            AppUser user = new AppUser
            {
                Email = model.Email,
                UserName = model.Username,
                PhoneNumber = model.Phone,
                Address = model.Address
            };
            // * Save on user manager
            var resultCreate = await Users.CreateAsync(user, model.Password);
            if (!resultCreate.Succeeded)
                return resultCreate;

            // * If memeber add claim
            if (role == "Member")
            {
                var resultClaim = await this.SetClaimAsync(user.UserName, "Points", "0");
                if (!resultClaim.Succeeded)
                    return resultClaim;
            }
                 

            // * Add role to the user
            return await Users.AddToRoleAsync(user, role);
        }


        /// <summary>
        /// Searches the user manager for a user given his username
        /// </summary>
        /// <param name="username">The username given</param>
        /// <returns></returns>
        public async Task<AppUser> FindByUsername(string username)
        {
            // * Search on UserManager by username
            return await this.Users.FindByNameAsync(username);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AppUser>> GetUsers(string role)
        {
            return await this.Users.GetUsersInRoleAsync(role);
        }


        /// <summary>
        /// Get a claim of a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public async Task<string> GetClaimAsync(string username, string claim)
        {
            AppUser user = await this.FindByUsername(username);
            IList<Claim> claims = (await this.Users.GetClaimsAsync(user));
            if (claims.Any())
                return claims.Where(uc => uc.Type == claim).Select(uc => uc.Value).First();
            return null;
        }

        /// <summary>
        /// Set or update a claim of a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="claim"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IdentityResult> SetClaimAsync(string username, string claim, string value)
        {
            AppUser user = await this.FindByUsername(username);
            Claim _claim = new Claim(claim, value);

            var resultRemove = await this.RemoveClaimAsync(username, claim);
            if (resultRemove != null && !resultRemove.Succeeded)
                return resultRemove;

            return await this.Users.AddClaimAsync(user, _claim);
        }

        /// <summary>
        /// Remove a claim of a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RemoveClaimAsync(string username, string claim)
        {
            AppUser user = await this.FindByUsername(username);
            IList<Claim> claims = (await this.Users.GetClaimsAsync(user));
            if (claims.Any())
            {
                Claim temp_claim = claims.Where(uc => uc.Type == claim).First();
                if (temp_claim != null)
                    return await this.Users.RemoveClaimAsync(user, temp_claim);
            }
            return null;
        }

        /// <summary>
        /// Remove a user given a username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IdentityResult> RemoveUser(string username)
        {
           return await this._userManager.DeleteAsync(await this.FindByUsername(username));
        }
        #endregion
    }
}
