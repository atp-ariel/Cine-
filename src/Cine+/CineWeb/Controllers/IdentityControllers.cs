using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Identity;

namespace CineWeb.Controllers{
    public partial class IdentityController : Controller
    {
        private CineUserManager _cineUserManager;

        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._cineUserManager = new CineUserManager(userManager, signInManager);
        }
    }
}