using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Country> listCountries = _context.Country;
            return View(listCountries);
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
                _context.Country.Add(country);
                _context.SaveChanges();
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

            var country = _context.Country.Find(id);

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
                _context.Country.Update(country);
                _context.SaveChanges();
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

            var country = _context.Country.Find(id);

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
            var country = _context.Country.Find(id);

            if (country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            _context.SaveChanges();
            TempData["message"] = "Se ha eliminado país correctamente";
            return RedirectToAction("Index");
        }
    }
}
