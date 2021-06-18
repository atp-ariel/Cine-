using Microsoft.AspNetCore.Mvc;
using System;
using ServiceLayer.Statistics;
using RepositoryLayer;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    [Authorize(Roles="Manager")]
    public class StatisticsController : Controller
    {
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
            var ticket = new TicketSalesStatisticsDay(new ApplicationDbContext());
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
            var ticket = new TicketSalesStatisticsMonth(new ApplicationDbContext());
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
            var ticket = new TicketSalesStatisticsYear(new ApplicationDbContext());
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
            var ticket = new TicketSalesStatisticsPeriod(new ApplicationDbContext());
            ticket.Filter(start, end);
            return View(ticket.TicketsSold);
        }
    }
}
