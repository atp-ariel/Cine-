using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Identity;
using System.Threading.Tasks;
namespace CineWeb.Controllers
{
    public partial class IdentityController : Controller
    {
        private CinemaUserFacade _cineUserManager;

        public IdentityController(IAuthorizeUser auth, IUserStore userStore)
        {
            this._cineUserManager = new CinemaUserFacade(auth, userStore);
        }

        public async  Task<IActionResult> PersonalInfo( string username)
        {
            var user = await _cineUserManager.FindUserByUserName(username);
            return View(user);
        }
    }
}