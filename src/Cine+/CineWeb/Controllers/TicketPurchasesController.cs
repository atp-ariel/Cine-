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

        public IActionResult TicketPurchaseCreate(DateTime start,DateTime end,int cinema,float price)
        {
            TempData["start"] = start;
            TempData["end"] = end;
            TempData["cinema"] = cinema;
            TempData["price"] = price;

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
                physicalTicketPurchase.BatchScheduleStartTime = (DateTime) TempData["start"];
                physicalTicketPurchase.BatchScheduleEndTime = (DateTime) TempData["end"];
                physicalTicketPurchase.CinemaId = (int)TempData["cinema"];
                physicalTicketPurchase.Price = (float)TempData["price"];

                IEnumerable<DiscountList> listDiscountList = _context.DiscountList.Include(m=>m.Discounts).ToList();
                var discountList = new DiscountList();
                bool find = false;

                foreach (var item in listDiscountList)
                {
                    if (item.Discounts.Count != discounts.Length)
                        continue;
                    else
                    {
                        if (SameDiscounts(item, discounts)) 
                        {
                            discountList = item;
                            find = true;
                            break;
                        }
                    }
                }

                if (discountList.Discounts.Count == 0) 
                {
                    foreach (var item in discounts)
                    {
                        var discount = _context.Discount.Find(item);
                        discount.DiscountLists.Add(discountList);
                        discountList.Discounts.Add(discount);
                    }
                }

                if (!find)
                {
                    _context.DiscountList.Add(discountList);
                    _context.SaveChanges();
                }

                physicalTicketPurchase.DiscountListId = discountList.Id;

                _context.PhysicalTicketPurchase.Add(physicalTicketPurchase);
                _context.SaveChanges();
                TempData["message"] = "Compra realizada exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.Seats = _context.Seat.Where(x => x.CinemaId == (int)TempData["cinema"]);
            ViewBag.Discounts = _context.Discount;

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnlineTicketPurchaseCreate(OnlineTicketPurchase onlineTicketPurchase, int[] discounts)
        {
            if (ModelState.IsValid)
            {
                onlineTicketPurchase.BatchScheduleStartTime = (DateTime)TempData["start"];
                onlineTicketPurchase.BatchScheduleEndTime = (DateTime)TempData["end"];
                onlineTicketPurchase.CinemaId = (int)TempData["cinema"];
                onlineTicketPurchase.Price = (float)TempData["price"];

                IEnumerable<DiscountList> listDiscountList = _context.DiscountList.Include(m => m.Discounts).ToList();
                var discountList = new DiscountList();
                bool find = false;

                foreach (var item in listDiscountList)
                {
                    if (item.Discounts.Count != discounts.Length)
                        continue;
                    else
                    {
                        if (SameDiscounts(item, discounts))
                        {
                            discountList = item;
                            find = true;
                            break;
                        }
                    }
                }

                if (discountList.Discounts.Count == 0)
                {
                    foreach (var item in discounts)
                    {
                        var discount = _context.Discount.Find(item);
                        discount.DiscountLists.Add(discountList);
                        discountList.Discounts.Add(discount);
                    }
                }

                if (!find)
                {
                    _context.DiscountList.Add(discountList);
                    _context.SaveChanges();
                }

                onlineTicketPurchase.DiscountListId = discountList.Id;

                _context.OnlineTicketPurchase.Add(onlineTicketPurchase);
                _context.SaveChanges();
                TempData["message"] = "Compra realizada exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.Seats = _context.Seat.Where(x => x.CinemaId == (int)TempData["cinema"]);
            ViewBag.Discounts = _context.Discount;

            return View();
        }

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

        private bool SameDiscounts(DiscountList list,int[] discounts) 
        {
            int i = 0;
            foreach (var item in list.Discounts)
            {
                if (item.Id != discounts[i])
                    return false;
                i++;
            }
            return true;
        }
    }
}
