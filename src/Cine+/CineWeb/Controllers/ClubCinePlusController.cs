using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Identity;
using ServiceLayer.Identity;

namespace CineWeb.Controllers
{
    public partial class ClubCinePlusController : Controller
    {
        private CineUserManager _cineUserManager;

        public ClubCinePlusController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._cineUserManager = new CineUserManager(userManager, signInManager, roleManager);
        }

    }
}