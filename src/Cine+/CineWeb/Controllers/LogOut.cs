using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    public partial class IdentityController : Controller
    {
        [Authorize]
        public IActionResult LogOut()
        {
            _cineUserManager.LogOut();
            return RedirectToAction("SignIn", "Identity", null);
        }
    }
}
