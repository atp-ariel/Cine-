using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Cinema> cinemas = _context.Cinema;
            return View(cinemas);
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
                Save(cinema);
                _context.SaveChanges();
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

            var cinema = _context.Cinema.Find(id);

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
                _context.Cinema.Remove(cinema);
                _context.SaveChanges();
                Save(cinema);
                _context.SaveChanges();
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

            var cinema = _context.Cinema.Find(id);

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
            var cinema = _context.Cinema.Find(id);

            if (cinema == null)
            {
                return NotFound();
            }

            _context.Cinema.Remove(cinema);
            _context.SaveChanges();
            TempData["message"] = "Se ha eliminado actor correctamente";
            return RedirectToAction("Index");
        }

        public void Save(Cinema cinema) 
        {
            for (int i = 1; i <= cinema.Capacity; i++)
            {
                Seat seat = new Seat
                {
                    Id = i,
                    CinemaId = cinema.Id,
                    Cinema = cinema,
                };
                _context.Seat.Add(seat);
            }
            _context.Cinema.Add(cinema);
        }
    }
}
