using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class GenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Genre> listGenres = _context.Genre;
            return View(listGenres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Genre.Add(genre);
                _context.SaveChanges();
                TempData["message"] = "Se ha agregado género correctamente";
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

            var genre = _context.Genre.Find(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Genre.Update(genre);
                _context.SaveChanges();
                TempData["message"] = "Se ha actualizado género correctamente";
                return RedirectToAction("Index");

            }
            return View();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var genre = _context.Genre.Find(id);

            if (genre== null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGenre(int? id)
        {
            var genre = _context.Genre.Find(id);

            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            _context.SaveChanges();
            TempData["message"] = "Se ha eliminado género correctamente";
            return RedirectToAction("Index");
        }
    }
}
