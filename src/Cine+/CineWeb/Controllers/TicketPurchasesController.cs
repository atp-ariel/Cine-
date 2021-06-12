using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public class TicketPurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketPurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() 
        {
            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).Where(m=>m.ScheduleStartTime>DateTime.Now).ToList();
            return View(listBatches);
        }

        public IActionResult PhysicalTicketPurchaseCreate(DateTime start,DateTime end,int cinema)
        {
            ViewBag.Batch = _context.Batch.Find(cinema, start, end);
            ViewBag.Seats = _context.Seat.Where(x => x.CinemaId == cinema);
            ViewBag.Discounts = _context.Discount;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhysicalTicketPurchaseCreate(PhysicalTicketPurchase physicalTicketPurchase,int[] discounts)
        {
            if (ModelState.IsValid)
            {
                var discountList = new DiscountList();
                foreach (var item in discounts)
                {
                    var discount = _context.Discount.Find(item);
                    discountList.Discounts.Add(discount);
                    discountList.TotalDiscounted += discount.DiscountedMoney;
                }
                _context.DiscountList.Add(discountList);

                physicalTicketPurchase.DiscountListId = discountList.Id;
                physicalTicketPurchase.DiscountList = discountList;

                _context.PhysicalTicketPurchase.Add(physicalTicketPurchase);
                _context.SaveChanges();
                TempData["message"] = "Compra realizada exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.Seats = _context.Seat.Where(x => x.CinemaId == physicalTicketPurchase.CinemaId);
            ViewBag.Discounts = _context.Discount;

            return View();
        }

        public IActionResult Edit(DateTime? start, DateTime? end, int? cinema)
        {
            if (cinema == null || cinema == 0 || start == null || end == null)
            {
                return NotFound();
            }

            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();

            var batch = _context.Batch.Find(cinema, start, end);

            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Batch batch)
        {

            if (ModelState.IsValid)
            {
                _context.Batch.Update(batch);
                _context.SaveChanges();
                TempData["message"] = "Se ha actualizado tanda correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(DateTime? start, DateTime? end, int? cinema)
        {
            if (cinema == null || cinema == 0 || start == null || end == null)
            {
                return NotFound();
            }

            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();

            var batch = _context.Batch.Find(cinema, start, end);

            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBatch(Batch batch)
        {

            if (batch == null)
            {
                return NotFound();
            }

            _context.Batch.Remove(batch);
            _context.SaveChanges();
            TempData["message"] = "Se ha eliminado función correctamente";
            return RedirectToAction("Index");
        }

    }
}
