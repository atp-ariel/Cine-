using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Actor> listActors = _context.Actor;
            return View(listActors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Actor.Add(actor);
                _context.SaveChanges();
                TempData["message"] = $"Se ha agregado el actor '{actor.Name}' correctamente";
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

            var actor = _context.Actor.Find(id);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Actor.Update(actor);
                _context.SaveChanges();
                TempData["message"] = $"Se ha actualizado actor '{actor.Name}' correctamente";
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

            var actor = _context.Actor.Find(id);

            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteActor(int? id)
        {
            var actor = _context.Actor.Find(id);

            if (actor == null)
            {
                return NotFound();
            }

            _context.Actor.Remove(actor);
            _context.SaveChanges();
            TempData["message"] = $"Se ha eliminado el actor '{actor.Name}' correctamente";
            return RedirectToAction("Index");
        }
    }
}
