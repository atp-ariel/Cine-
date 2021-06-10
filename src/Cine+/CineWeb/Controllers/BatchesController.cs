using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CineWeb.Controllers
{
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();
            return View(listBatches);
        }

        public IActionResult Create()
        {
            ViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Batch batch, int? cinema, int? movie)
        {
            if (ModelState.IsValid)
            {

                batch = Save(batch, cinema, movie);

                _context.Batch.Add(batch);
                _context.SaveChanges();

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

            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();

            var batch = _context.Batch.Find(id);

            if (batch == null)
            {
                return NotFound();
            }

            ViewBags();

            return View(batch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Batch batch, int? cinema, int? movie)
        {

            if (ModelState.IsValid)
            {
                _context.Batch.Remove(batch);
                _context.SaveChanges();

                batch = Save(batch, cinema, movie);

                _context.Batch.Add(batch);
                _context.SaveChanges();

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

            var movie = _context.Movie.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Genres = _context.Genre;
            ViewBag.Actors = _context.Actor;
            ViewBag.Countries = _context.Country;

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMovie(int? id)
        {
            var movie = _context.Movie.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            _context.SaveChanges();
            TempData["message"] = "Se ha eliminado película correctamente";
            return RedirectToAction("Index");
        }


        public Batch Save(Batch batch, int? cinemaId, int? movieId)
        {
            if (cinemaId != null && cinemaId != 0)
            {
                Cinema cinema = _context.Cinema.Find(cinemaId);
                batch.Cinema=cinema;
            }

            if (movieId != null && movieId != 0)
            {
                Movie movie = _context.Movie.Find(movieId);
                batch.Movie = movie;
                movie.Batches.Add(batch);
            }

            return batch;
        }

        public void ViewBags()
        {
            ViewBag.Cinemas = _context.Cinema;
            ViewBag.Movies = _context.Movie;
        }
    }
}
