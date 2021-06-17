using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> listMovies = _context.Movie.Include(m => m.Genres).Include(m => m.Countries).Include(m => m.Actors).Include(m => m.Rating).ToList();
            return View(listMovies);
        }

        public IActionResult Create()
        {
            ViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie, int rating, int[] countries = null, int[] genres = null, int[] actors = null)
        {
            if (ModelState.IsValid)
            {

                Save(movie, rating, countries, genres, actors);

                _context.Movie.Add(movie);
                _context.SaveChanges();

                TempData["message"] = "Se ha creado película correctamente";

                return RedirectToAction("Index");
            }

            ViewBags();
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            IEnumerable<Movie> listMovies = _context.Movie.Include(m => m.Genres).Include(m => m.Countries).Include(m => m.Actors).ToList();

            var movie = _context.Movie.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            ViewBags();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie, int rating, int[] countries = null, int[] genres = null, int[] actors = null)
        {
            IEnumerable<Movie> listMovies = _context.Movie.Include(m => m.Genres).Include(m => m.Countries).Include(m => m.Actors).Include(m => m.Batches).ToList();

            movie = _context.Movie.Find(movie.Id);

            if (ModelState.IsValid)
            {
                _context.Movie.Remove(movie);
                _context.SaveChanges();

                movie.Countries.Clear();
                movie.Genres.Clear();
                movie.Actors.Clear();

                Save(movie, rating, countries, genres, actors);

                foreach (var item in movie.Batches)
                {
                    _context.Batch.Add(item);
                }

                _context.Movie.Add(movie);
                _context.SaveChanges();

                TempData["message"] = "Se ha editado película correctamente";
                return RedirectToAction("Index");
            }

            ViewBags();

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            IEnumerable<Movie> listMovies = _context.Movie.Include(m => m.Genres).Include(m => m.Countries).Include(m => m.Actors).ToList();

            var movie = _context.Movie.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            ViewBags();

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


        public void Save(Movie movie, int rating, int[] countries = null, int[] genres = null, int[] actors = null)
        {
            if (rating != 0)
            {
                Rating auxRating = _context.Rating.Find(rating);
                auxRating.Movies.Add(movie);
                movie.RatingId = rating;
                movie.Rating = auxRating;
            }

            if (countries != null)
            {
                foreach (var item in countries)
                {
                    Country country = _context.Country.Find(item);
                    movie.Countries.Add(country);
                    country.Movies.Add(movie);
                }

            }

            if (genres != null)
            {
                foreach (var item in genres)
                {
                    Genre genre = _context.Genre.Find(item);
                    movie.Genres.Add(genre);
                    genre.Movies.Add(movie);
                }
            }

            if (actors != null)
            {
                foreach (var item in actors)
                {
                    Actor actor = _context.Actor.Find(item);
                    movie.Actors.Add(actor);
                    actor.Movies.Add(movie);
                }
            }
        }

        public void ViewBags()
        {
            ViewBag.Genres = _context.Genre;
            ViewBag.Actors = _context.Actor;
            ViewBag.Countries = _context.Country;
            ViewBag.Ratings = _context.Rating;
        }
    }
}