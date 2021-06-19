using Microsoft.AspNetCore.Mvc;
using System;
using ServiceLayer.Statistics;
using ServiceLayer;
using RepositoryLayer;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using DomainLayer;
namespace CineWeb.Controllers
{
    [Authorize(Roles="Manager")]
    public class StatisticsController : Controller
    {
        private MoviesManager movies;
        private ApplicationDbContext dbcontext;

        public StatisticsController(ApplicationDbContext context, IRepository<Movie> moviesRepo, IRepository<Country> country, IRepository<Actor> actor, IRepository<Genre> genres, IRepository<Rating> rating)
        {
            movies = new MoviesManager(moviesRepo, country, actor, genres, rating);
            dbcontext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TicketPerDay()
        {
            return View(null);
        }

        [HttpPost]
        public IActionResult TicketPerDay(DateTime date, int hours)
        {
            var ticket = new TicketSalesStatisticsDay(dbcontext);
            ticket.Filter(date, hours);
            return View((x: ticket.Hours, y: ticket.TicketsSoldHour));
        }

        public IActionResult TicketPerMonth()
        {
            return View(null);
        }
        [HttpPost]
        public IActionResult TicketPerMonth(DateTime month)
        {
            var ticket = new TicketSalesStatisticsMonth(dbcontext);
            ticket.Filter(month);
            return View((x: ticket.Months, y: ticket.TicketsSoldMonth));
        }
        public IActionResult TicketPerYear()
        {
            return View(null);
        }
        [HttpPost]
        public IActionResult TicketPerYear(DateTime month)
        {
            var ticket = new TicketSalesStatisticsYear(dbcontext);
            ticket.Filter(month);
            return View((x: ticket.Months, y: ticket.TicketsSoldYear));
        }

        public IActionResult TicketPerPeriod()
        {
            return View(-1);
        }

        [HttpPost]
        public IActionResult TicketPerPeriod(DateTime start, DateTime end)
        {
            var ticket = new TicketSalesStatisticsPeriod(dbcontext);
            ticket.Filter(start, end);
            return View(ticket.TicketsSold);
        }

        public IActionResult TicketMovie()
        {
            return View(-1);
        }

        [HttpPost]
        public IActionResult TicketMovie(string title)
        {
            var ticket = new TicketSalesStatisticsMovie(dbcontext);
            ticket.Filter(movies.FindById(movies.GetAllMovies().Where(m => m.Title.ToUpper() == title.ToUpper()).First().Id));
            return View(ticket.TicketsSold);
        }

        

        public IActionResult TicketCountry()
        {
            return View(-1);
        }

        [HttpPost]
        public IActionResult TicketCountry(string country)
        {
            var ticket = new TicketSalesStatisticsMovieCountry(dbcontext);
            ticket.Filter(movies.country.GetAllCountrys().Where(c => c.Name.ToUpper() == country.ToUpper()).First().Name);
            return View(ticket.TicketsSold);
        }

        public IActionResult TicketGenre()
        {
            return View(-1);
        }

        [HttpPost]
        public IActionResult TicketGenre(string genre)
        {
            var ticket = new TicketSalesStatisticsMovieGenre(dbcontext);
            ticket.Filter(movies.genres.GetAllGenres().Where(c => c.Name.ToUpper() == genre.ToUpper()).First().Name);
            return View(ticket.TicketsSold);
        }
        public IActionResult TicketRating()
        {
            return View(-1);
        }
        [HttpPost]
        public IActionResult TicketRating(string rating)
        {
            var ticket = new TicketSalesStatisticsMovieRating(dbcontext);
            ticket.Filter(dbcontext.Rating.Where(c => c.Name.ToUpper() == rating.ToUpper()).First().Name);
            return View(ticket.TicketsSold);
        }
    }
}
