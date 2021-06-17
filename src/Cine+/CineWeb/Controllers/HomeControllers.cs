using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System.Collections.Generic;
using System.Linq;
using ServiceLayer.Criteria;

namespace CineWeb.Controllers{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> listMovies = _context.Movie.Include(m => m.Genres).Include(m => m.Countries).Include(m => m.Actors).Include(m=>m.Rating).ToList();
            var criterion = new CriteriaManager();
            return View((criterion.GetSelectedCriterion().ApplyCriterion(10) ,listMovies));
        }

        public IActionResult Credits()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error501()
        {
            return View();
        }
    }
}