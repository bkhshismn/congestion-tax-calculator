using congestion_tax_calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace congestion_tax_calculator.Controllers
{
    public class PublicHolidayController : Controller
    {
        private readonly TaxDbContext _context;

        public PublicHolidayController(TaxDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            var publicHolidays = _context.PublicHolidays.ToList();
            return View(publicHolidays);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date")] PublicHoliday publicHoliday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicHoliday);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(publicHoliday);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicHoliday = _context.PublicHolidays.Find(id);
            if (publicHoliday == null)
            {
                return NotFound();
            }
            return View(publicHoliday);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date")] PublicHoliday publicHoliday)
        {
            if (id != publicHoliday.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(publicHoliday);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(publicHoliday);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicHoliday = _context.PublicHolidays
                .FirstOrDefault(m => m.Id == id);
            if (publicHoliday == null)
            {
                return NotFound();
            }

            return View(publicHoliday);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var publicHoliday = _context.PublicHolidays.Find(id);
            _context.PublicHolidays.Remove(publicHoliday);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
