using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class MoviesController : Controller
    {
        private readonly MoviesManager movies;
        public MoviesController(IRepository<Movie> moviesRepo, IRepository<Country> country, IRepository<Actor> actor, IRepository<Genre> genres, IRepository<Rating> rating)
        {
            movies = new MoviesManager(moviesRepo, country, actor, genres, rating);
        }

        public IActionResult Index()
        {
            return View(movies.GetAllMovies());
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

                movies.UpdateRelations(movie, rating, countries, genres, actors);

                movies.AddMovie(movie);

                TempData["message"] = "Se ha creado película correctamente";

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


            var movie = movies.FindById((int)id);

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
            var movie = movies.FindById((int)id);

            if (movie == null)
            {
                return NotFound();
            }

            movies.DeleteMovie(movie.Id);

            TempData["message"] = "Se ha eliminado película correctamente";
            return RedirectToAction("Index");
        }


       

        private void ViewBags()
        {
            ViewBag.Genres = movies.genres.GetAllGenres();
            ViewBag.Actors = movies.actors.GetAllActors();
            ViewBag.Countries = movies.country.GetAllCountrys();
            ViewBag.Ratings = new ApplicationDbContext().Rating;
        }
    }
}