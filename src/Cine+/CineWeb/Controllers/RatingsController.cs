using DomainLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class RatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Rating> listRatings = _context.Rating;
            return View(listRatings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Rating.Add(rating);
                _context.SaveChanges();
                TempData["message"] = $"Se ha agregado la clasificación '{rating.Name}' correctamente";
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

            var rating = _context.Rating.Find(id);

            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Rating.Update(rating);
                _context.SaveChanges();
                TempData["message"] = $"Se ha actualizado clasificación '{rating.Name}' correctamente";
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

            var rating = _context.Rating.Find(id);

            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRating(int? id)
        {
            var rating = _context.Rating.Find(id);

            if (rating == null)
            {
                return NotFound();
            }

            _context.Rating.Remove(rating);
            _context.SaveChanges();
            TempData["message"] = $"Se ha eliminado la clasificación '{rating.Name}' correctamente";
            return RedirectToAction("Index");
        }
    }
}
