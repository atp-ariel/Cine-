using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Identity;
using ServiceLayer.PaymentGateway;


namespace CineWeb.Controllers
{
    public class TicketPurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CinemaUserFacade _cineUserManager;

        public TicketPurchasesController(ApplicationDbContext context, IAuthorizeUser auth, IUserStore userStore)
        {
            _context = context;
            _cineUserManager = new CinemaUserFacade(auth, userStore);
        }

        public IActionResult Index(int id)
        {
            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Where(m => m.Movie.Id == id && m.ScheduleStartTime > DateTime.Now).ToList();
            return View(listBatches);
        }

        public IActionResult SeatCount(DateTime start, DateTime end, int cinema, int buyForm)
        {
            TempData["start"] = start;
            TempData["end"] = end;
            TempData["cinema"] = cinema;
            TempData["buyForm"] = buyForm;
            return View();
        }

        public IActionResult TicketsPurchase(int count, string code)
        {
            TempData["code"] = code;
            var seats = _context.Seat.Where(x => x.CinemaId == (int)TempData["cinema"]).ToList();
            bool[] reserved = new bool[seats.Count];
            bool[] marked = new bool[seats.Count];

            int i = 0;
            foreach (var item in seats)
            {
                if (_context.TicketPurchase.Find((int)TempData["cinema"], (DateTime)TempData["start"], (DateTime)TempData["end"], item.Id) != null)
                    reserved[i] = true;
                else if (count > 0)
                {
                    marked[i] = true;
                    count--;
                }
                i++;
            }

            ViewBag.Reserved = reserved;
            ViewBag.Marked = marked;

            return View(seats);
        }


        public IActionResult DiscountLists(int[] seats)
        {
            if (seats.Length != 0)
            {
                TempData["seats"] = seats;

                string seatscode = "";
                foreach (var item in seats)
                {
                    seatscode += "-"+item.ToString();
                }
                TempData["codeSeats"] = ((DateTime)TempData["start"]).ToString() + "-" + ((DateTime)TempData["end"]).ToString() + "-" + ((int)TempData["cinema"]).ToString() + seatscode;

                float tp = 0f;
                TempData["totalPrice"] = tp.ToString();
                TempData["totalPoints"] = tp.ToString();
            }
            IEnumerable<Discount> discounts = _context.Discount;
            return View(discounts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TicketPurchaseCreate(int seat, int[] discounts)
        {
            TicketPurchase ticketPurchase;

            if ((int)TempData["buyForm"] == 0)
            {
                ticketPurchase = new PhysicalTicketPurchase
                {
                    BatchScheduleStartTime = (DateTime)TempData["start"],
                    BatchScheduleEndTime = (DateTime)TempData["end"],
                    CinemaId = (int)TempData["cinema"],
                    SeatId = seat,
                    AppUserId = (string)TempData["code"],
                    Code = (string)TempData["codeSeats"]
                };
            }
            else
            {
                ticketPurchase = new OnlineTicketPurchase
                {
                    BatchScheduleStartTime = (DateTime)TempData["start"],
                    BatchScheduleEndTime = (DateTime)TempData["end"],
                    CinemaId = (int)TempData["cinema"],
                    SeatId = seat,
                    AppUserId = (string)TempData["code"],
                    Code = (string)TempData["codeSeats"]
                };
            }

            var batch = _context.Batch.Find(ticketPurchase.CinemaId, ticketPurchase.BatchScheduleStartTime, ticketPurchase.BatchScheduleEndTime);
            float price = batch.TicketPrice;

            int[] aux = (int[])TempData["seats"];
            int[] seats = new int[aux.Length];
            aux.CopyTo(seats, 0);

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

            foreach (var item in discountList.Discounts)
            {
                price -= item.DiscountedMoney;
            }

            if (price < 0)
                price = 0;

            ticketPurchase.Price = price;

            float temp = float.Parse((string)TempData["totalPrice"]);
            float tp = temp + ticketPurchase.Price;
            TempData["totalPrice"] = tp.ToString();

            temp = float.Parse((string)TempData["totalPoints"]);
            tp = temp + ticketPurchase.PointsSpent;
            TempData["totalPoints"] = tp.ToString();

            ticketPurchase.DiscountListId = discountList.Id;

            _context.TicketPurchase.Add(ticketPurchase);
            _context.SaveChanges();

            return RedirectToAction("DiscountLists");
        }

        public async Task<IActionResult> Pay()
        {
            if (TempData["code"] != null)
            {
                var user = (await _cineUserManager.GetAllUsersBy("Member")).Where(c => c.Id == (string)TempData["code"]).First();
                ViewBag.PointsUser = float.Parse(await _cineUserManager.GetClaim(user.UserName, "Points"));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(int buyForm,int payForm,string creditCard, string partnerCode)
        {
            if (buyForm == 1 && payForm == 0)
            {
                var seats = _context.TicketPurchase.Where(m => m.Code == (string)TempData["codeSeats"]);
                BankTeller bank = new BankTeller();
                if (!bank.Pay())
                {
                    foreach (var item in seats)
                    {
                        _context.TicketPurchase.Remove(item);
                    }
                    _context.SaveChanges();
                    return RedirectToAction("PayError");
                }

                foreach (var item in seats)
                {
                    ((OnlineTicketPurchase)item).CreditCard = creditCard;
                }
            }

            if (partnerCode != null)
            {
                var user = (await _cineUserManager.GetAllUsersBy("Member")).Where(c => c.Id == partnerCode).First();
                float points = float.Parse(await _cineUserManager.GetClaim(user.UserName, "Points"));
                if (payForm == 0)
                {
                    points += 5 * ((int[])TempData["seats"]).Length;
                }
                else
                {
                    
                    var batch = _context.Batch.Find((int)TempData["cinema"], (DateTime)TempData["start"], (DateTime)TempData["end"]);
                    points -= batch.TicketPoints * ((int[])TempData["seats"]).Length;
                    var seats = _context.TicketPurchase.Where(m => m.Code == (string)TempData["codeSeats"]);
                    foreach (var item in seats)
                    {
                        item.PointsSpent = batch.TicketPoints;
                    }
                }
                await _cineUserManager.SetClaim(user.UserName, "Points", points);
            }

            var spots= _context.TicketPurchase.Where(m => m.Code == (string)TempData["codeSeats"]);
            foreach (var item in spots)
            {
                item.Paid = true;
            }

            _context.SaveChanges();
            return RedirectToAction("ShowCode", "TicketPurchases");
        }

        public IActionResult ShowCode() 
        {
            return View();
        }

        public IActionResult CancelBuy() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelBuy(string codeCard, string codeBuy)
        {
            var buys = _context.TicketPurchase.Where(m => m.Code == codeBuy);
            foreach (var item in buys)
            {
                if (item.PointsSpent > 0) 
                {
                    var user = (await _cineUserManager.GetAllUsersBy("Member")).Where(c => c.Id == codeCard).First();
                    float points = float.Parse(await _cineUserManager.GetClaim(user.UserName, "Points"));
                    points += item.PointsSpent;
                    await _cineUserManager.SetClaim(user.UserName, "Points", points);
                }
                _context.TicketPurchase.Remove(item);
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult PayError() 
        {
            return View();
        }

        private bool SameDiscounts(DiscountList list, int[] discounts)
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
