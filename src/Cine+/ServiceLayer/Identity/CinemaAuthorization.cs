using DomainLayer.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ServiceLayer.Identity
{
    public class CinemaAuthorization : IAuthorizeUser
    {
        #region Fields
        private readonly SignInManager<AppUser> _signInManager;

        #endregion

        #region Properties
        public SignInManager<AppUser> SignInManager => _signInManager;
        #endregion

        #region Constructors
        public CinemaAuthorization(SignInManager<AppUser> signIn)
        {
            this._signInManager = signIn;
        }
        #endregion


        #region Methods
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
        #endregion
    }
}
