using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Identity;
using DomainLayer.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    public class ClubCinePlusController : Controller
    {
        private CineUserManager _cineUserManager;

        public ClubCinePlusController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._cineUserManager = new CineUserManager(userManager, signInManager, roleManager);
        }

        [Authorize(Roles = "BoxOfficer, Manager")]
        public IActionResult GetMembersClub(){
            return View(_cineUserManager.GetUsers());
        }
    }
}