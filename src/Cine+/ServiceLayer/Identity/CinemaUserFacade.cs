using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DomainLayer.Identity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using System.Security.Claims;
using System;


namespace ServiceLayer.Identity
{
    public class CinemaUserFacade
    {
        private readonly IUserStore _userStore;
        private readonly IAuthorizeUser _authorizeUser;

        public CinemaUserFacade(IAuthorizeUser authorizeUser, IUserStore userStore)
        {
            this._userStore = userStore;
            this._authorizeUser = authorizeUser;
        }

        #region FacadeMethods
        public async Task<AppUser> FindUserByUserName(string username) => await this._userStore.FindByUsername(username);

        public async Task<IEnumerable<AppUser>> GetAllUsersBy(string role)
        {
            return await this._userStore.GetUsers(role);
        }

        public async Task<string> GetClaim(string username, string claim) => await this._userStore.GetClaimAsync(username, claim);

        public async Task<IdentityResult> SetClaim(string username, string claim, object value) => await this._userStore.SetClaimAsync(username, claim, value.ToString());

        public async Task<IdentityResult> SignUpUser(SignUpModel model, string role) => await this._userStore.SignUp(model, role);

        public async Task<IdentityResult> DeleteUser(string username) => await this._userStore.RemoveUser(username);

        public async Task<SignInResult> Login(SignInModel model) => await this._authorizeUser.Login(model);

        public void LogOut() => this._authorizeUser.Logout();

        public async Task<IdentityResult> Promote(string username, string role) => await this._userStore.PromoteAsync(username, role);
        #endregion
    }
}
