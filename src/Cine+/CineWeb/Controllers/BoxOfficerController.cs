using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Identity;
using DomainLayer.Identity;
namespace CineWeb.Controllers
{
    public class BoxOfficerController : Controller
    {
        private CineUserManager _cineUserManager;

        public BoxOfficerController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._cineUserManager = new CineUserManager(userManager, signInManager);
        }
        public IActionResult GetMembersClub(){
            return View(_cineUserManager.GetUsers());
        }
    }
}