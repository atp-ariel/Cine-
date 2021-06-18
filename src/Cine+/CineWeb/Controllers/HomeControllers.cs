using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System.Collections.Generic;
using System.Linq;
using ServiceLayer.Criteria;
using ServiceLayer;


namespace CineWeb.Controllers{
    public class HomeController : Controller
    {
        private MoviesManager movies;

        public HomeController(IRepository<Movie> moviesRepo, IRepository<Country> country, IRepository<Actor> actor, IRepository<Genre> genres, IRepository<Rating> rating)
        {
            movies = new MoviesManager(moviesRepo, country, actor, genres, rating);
        }

        public IActionResult Index()
        {
            var criterion = new CriteriaManager();
            return View((criterion.GetSelectedCriterion().ApplyCriterion(10) ,movies.GetAllMovies()));
        }

        public IActionResult Credits()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Billboard()
        {
            return View(movies.GetAllMovies());
        }

        public IActionResult Error501()
        {
            return View();
        }
    }
}