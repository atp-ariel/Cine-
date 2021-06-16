using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Criteria;
namespace CineWeb.Controllers
{

    public class CriteriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Manager")]
        public IActionResult SelectCriteria()
        {
            return View();
        }
    }
}
