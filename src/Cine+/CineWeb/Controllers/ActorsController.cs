using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using RepositoryLayer;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    [Authorize(Roles="Manager")]
    public class ActorsController : Controller
    {
        private readonly ActorManager actorManager;

        public ActorsController(IRepository<Actor> actors)
        {
            actorManager = new ActorManager(actors);
        }

        public IActionResult Index()
        {
            return View(actorManager.GetAllActors());
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
                actorManager.AddActor(actor);
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

            var actor = actorManager.FindById((int)id);

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
                actorManager.UpdateActor(actor);
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

            var actor = actorManager.FindById((int)id);

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
            var actor = actorManager.FindById((int)id);
                
            if (actor == null)
            {
                return NotFound();
            }

            actorManager.DeleteActor((int)id);
            TempData["message"] = $"Se ha eliminado el actor '{actor.Name}' correctamente";
            return RedirectToAction("Index");
        }
    }
}
