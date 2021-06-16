using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ServiceLayer;
using RepositoryLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class GenresController : Controller
    {
        private readonly GenreManager _manager;
        public GenresController(IRepository<Genre> repository)
        {
            this._manager = new GenreManager(repository);
        }

        public IActionResult Index()
        {
            return View(_manager.GetAllGenres());
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
                _manager.AddGenre(genre);
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

            var genre = _manager.FindById((int)id);

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
                _manager.UpdateGenre(genre);
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

            var genre = _manager.FindById((int)id);

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
            var genre = _manager.FindById((int)id);

            if (genre == null)
            {
                return NotFound();
            }

            _manager.DeleteGenre(genre.Id);
            TempData["message"] = "Se ha eliminado género correctamente";
            return RedirectToAction("Index");
        }
    }
}
