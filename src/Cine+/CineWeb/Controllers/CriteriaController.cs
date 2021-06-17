using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Criteria;
using RepositoryLayer;

namespace CineWeb.Controllers
{

    public class CriteriaController : Controller
    {
        private CriteriaManager criteriaManager;

        public CriteriaController()
        {
            criteriaManager = new CriteriaManager();
        }

        public IActionResult Index()
        {
            return View(criteriaManager.GetCriterions());
        }

        [HttpPost]
        [Authorize(Roles ="Manager")]
        public IActionResult SelectCriteria(string selection)
        {
            criteriaManager.UpdateSelected(new ConfigRepository(), selection);
            return RedirectToAction("Index", "Home");
        }
    }
}
