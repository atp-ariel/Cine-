using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Identity;
using DomainLayer.Identity;

namespace CineWeb.Controllers{
    public partial class IdentityController : Controller
    {
        private CineUserManager _cineUserManager;

        public IdentityController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._cineUserManager = new CineUserManager(userManager, signInManager, roleManager);
        }
    }
}