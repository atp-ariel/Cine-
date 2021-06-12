using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public class DiscountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Discount> listDiscounts = _context.Discount;
            return View(listDiscounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Discount discount)
        {
            if (ModelState.IsValid)
            {
                _context.Discount.Add(discount);
                _context.SaveChanges();
                TempData["message"] = "Se ha agregado descuento correctamente";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var discount = _context.Discount.Find(id);

            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Discount discount)
        {
            if (ModelState.IsValid)
            {
                _context.Discount.Update(discount);
                _context.SaveChanges();
                TempData["message"] = "Se ha actualizado descuento correctamente";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var discount = _context.Discount.Find(id);

            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDiscount(int? id)
        {
            var discount = _context.Discount.Find(id);

            if (discount == null)
            {
                return NotFound();
            }

            _context.Discount.Remove(discount);
            _context.SaveChanges();
            TempData["message"] = "Se ha eliminado actor correctamente";
            return RedirectToAction("Index");
        }
    }
}
