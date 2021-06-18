using DomainLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServiceLayer;


namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CinemasController : Controller
    {
        private readonly CinemaManager cinemaManager;

        public CinemasController(IRepository<Cinema> cinemas)
        {
            cinemaManager = new CinemaManager(cinemas);
        }

        public IActionResult Index()
        {
            return View(cinemaManager.GetAllCinemas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinemaManager.AddCinema(cinema);
                TempData["message"] = "Se ha agregado sala correctamente";
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

            var cinema = cinemaManager.FindById((int)id);

            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinemaManager.UpdateCinema(cinema);

                TempData["message"] = "Se ha actualizado actor correctamente";
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

            var cinema = cinemaManager.FindById((int)id);

            if (cinema == null)
            {
                return NotFound();
            }

            return View(cinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCinema(int? id)
        {
            var cinema = cinemaManager.FindById((int)id);

            if (cinema == null)
            {
                return NotFound();
            }

            cinemaManager.DeleteCinema((int)id);
            TempData["message"] = "Se ha eliminado actor correctamente";
            return RedirectToAction("Index");
        }


    }
}
