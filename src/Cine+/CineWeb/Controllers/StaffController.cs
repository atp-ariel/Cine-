using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Identity;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Identity;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    [Authorize(Roles="Manager")]
    public class StaffController : Controller
    {
        private CinemaUserFacade _cineUserManager;

        public StaffController(IAuthorizeUser authorizeUser, IUserStore userStore)
        {
            this._cineUserManager = new CinemaUserFacade(authorizeUser, userStore);
        }

        public async Task<IActionResult> GetBoxOfficers()
        {
            var boxOfficers = await _cineUserManager.GetAllUsersBy("BoxOfficer");
            return View(boxOfficers);
        }

        public async Task<IActionResult> GetManagersUsers()
        {
            var managers = await _cineUserManager.GetAllUsersBy("Manager");
            return View(managers);
        }
    }
}
