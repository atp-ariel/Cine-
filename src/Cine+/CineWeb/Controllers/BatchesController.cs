using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CineWeb.Controllers
{
    [Authorize(Roles = "Manager")]
    public class BatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();
            return View(listBatches);
        }

        
        public IActionResult Create()
        {
            ViewBags();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                batch.Movie = _context.Movie.Find(batch.MovieId);
                batch.ScheduleEndTime = batch.ScheduleStartTime.Add(batch.Movie.DurationTime).AddMinutes(10);
                Schedule schedule = new Schedule { StartTime = batch.ScheduleStartTime, EndTime = batch.ScheduleEndTime };
                _context.Schedule.Add(schedule);
                _context.Batch.Add(batch);
                _context.SaveChanges();
                TempData["message"] = "Se ha creado función correctamente";
                return RedirectToAction("Index");
            }

            ViewBags();
            return View();
        }
        
        
        public IActionResult Edit(DateTime? start,DateTime? end, int? cinema)
        {
            if (cinema == null || cinema == 0|| start==null || end==null)
            {
                return NotFound();
            }

            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();

            var batch = _context.Batch.Find(cinema,start, end);

            if (batch == null)
            {
                return NotFound();
            }

            ViewBags();

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

            ViewBags();

            return View();
        }

        
        public IActionResult Delete(DateTime? start, DateTime? end, int? cinema)
        {
            if (cinema == null || cinema == 0 || start == null || end == null)
            {
                return NotFound();
            }

            IEnumerable<Batch> listBatches = _context.Batch.Include(m => m.Schedule).Include(m => m.Cinema).Include(m => m.Movie).ToList();

            var batch = _context.Batch.Find(cinema,start, end);

            if (batch == null)
            {
                return NotFound();
            }

            ViewBags();

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

        private void ViewBags()
        {
            ViewBag.Cinemas = _context.Cinema;
            ViewBag.Movies = _context.Movie;
        }
    }
}
