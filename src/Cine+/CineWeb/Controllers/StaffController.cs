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

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(SignUpModel model)
        {
            await this._cineUserManager.SignUpUser(model, "Manager");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddBoxOfficer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBoxOfficer(SignUpModel model)
        {
            await this._cineUserManager.SignUpUser(model, "BoxOfficer");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Promote(string username)
        {
            await this._cineUserManager.Promote(username, "Manager");
            return RedirectToAction("GetBoxOfficers", "Staff");
        }
    }
}
