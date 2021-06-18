using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServiceLayer;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CountriesController : Controller
    {
        private readonly CountryManager countryManager;

        public CountriesController(IRepository<Country> countryRepo)
        {
            countryManager = new CountryManager(countryRepo);
        }

        public IActionResult Index()
        {
            return View(countryManager.GetAllCountrys());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                countryManager.AddCountry(country);
                TempData["message"] = "Se ha agregado país correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var country = countryManager.FindById((int)id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                countryManager.UpdateCountry(country);
                TempData["message"] = "Se ha actualizado país correctamente";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var country = countryManager.FindById((int)id);

            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCountry(int? id)
        {
            var country = countryManager.FindById((int)id);

            if (country == null)
            {
                return NotFound();
            }

            countryManager.DeleteCountry((int)id);
            TempData["message"] = "Se ha eliminado país correctamente";
            return RedirectToAction("Index");
        }
    }
}
