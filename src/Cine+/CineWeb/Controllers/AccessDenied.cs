using Microsoft.AspNetCore.Mvc;

namespace CineWeb.Controllers
{
    public partial class IdentityController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
