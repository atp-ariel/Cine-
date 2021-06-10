using Microsoft.AspNetCore.Mvc;

namespace CineWeb.Controllers{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Credits()
        {
            return View();
        }
    }
}