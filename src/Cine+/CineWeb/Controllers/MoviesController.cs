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
        private readonly MoviesManager moviesManager;

        public MoviesController(IRepository<Movie> repo, IRepository<Country> country, IRepository<Actor> actors, IRepository<Genre> genres)
        {
            moviesManager = new MoviesManager(repo, country, actors, genres);
        }   

        public IActionResult Index()
        {
            return View(moviesManager.GetAllMovies());
        }

        public IActionResult Create() 
        {
            ViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie,int rating, int[] countries=null,int[] genres=null,int[] actors=null)
        {
            if (ModelState.IsValid) 
            {
                var listMovie = moviesManager.GetAllMovies();

                moviesManager.UpdateRelations(movie,rating,  countries, genres, actors);

                moviesManager.AddMovie(movie);

                TempData["message"] = "Se ha creado película correctamente";

                return RedirectToAction("Index");
            }

            ViewBags();
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            
            var listMovie = moviesManager.GetAllMovies();

            var movie = moviesManager.FindById((int)id);

            if (movie == null)
                return NotFound();

            ViewBags();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie, int rating, int[] countries = null, int[] genres = null, int[] actors = null)
        {
            moviesManager.GetAllMovies();

            movie = moviesManager.FindById(movie.Id);

            if (ModelState.IsValid)
            {
                moviesManager.DeleteMovie(movie.Id);

                movie.Countries.Clear();
                movie.Genres.Clear();
                movie.Actors.Clear();

                moviesManager.UpdateRelations(movie, rating, countries, genres, actors);

                moviesManager.AddBatchMovie(movie);

                moviesManager.AddMovie(movie);

                TempData["message"] = "Se ha editado película correctamente";
                return RedirectToAction("Index");
            }

            ViewBags();

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            moviesManager.GetAllMovies();

            var movie = moviesManager.FindById((int)id);
            if (movie == null)
                return NotFound();

            ViewBags();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMovie(int? id)
        {
            moviesManager.GetAllMovies();

            var movie = moviesManager.FindById((int)id);

            if (movie == null)
                return NotFound();

            moviesManager.DeleteMovie(movie.Id);
            TempData["message"] = "Se ha eliminado película correctamente";
            return RedirectToAction("Index");
        }
        private void ViewBags() 
        {
            ViewBag.Genres = moviesManager.genres.GetAllGenres();
            ViewBag.Actors = moviesManager.actors.GetAllActors();
            ViewBag.Countries = moviesManager.country.GetAllCountrys();
            ViewBag.Ratings = new ApplicationDbContext().Rating;
        }
    }
}
