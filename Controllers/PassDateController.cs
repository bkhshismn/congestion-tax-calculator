using Microsoft.AspNetCore.Mvc;
using congestion_tax_calculator.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator.Controllers
{
    public class PassDateController : Controller
    {
        private readonly TaxDbContext _context;

        public PassDateController(TaxDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            var passDates = _context.PassDates.Include(p => p.Vehicle).ToList();
            return View(passDates);
        }

        // GET
        public IActionResult Create()
        {
            ViewBag.Vehicles = _context.Vehicles.ToList(); 
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassDate passDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Vehicles = _context.Vehicles.ToList();
            return View(passDate);
        }

        // GET
        public IActionResult Edit(int id)
        {
            var passDate = _context.PassDates.Find(id);
            if (passDate == null)
            {
                return NotFound();
            }
            ViewBag.Vehicles = _context.Vehicles.ToList(); 
            return View(passDate);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PassDate passDate)
        {
            if (id != passDate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassDateExists(passDate.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Vehicles = _context.Vehicles.ToList(); 
            return View(passDate);
        }

        // GET
        public IActionResult Delete(int id)
        {
            var passDate = _context.PassDates.Include(p => p.Vehicle).FirstOrDefault(p => p.Id == id);
            if (passDate == null)
            {
                return NotFound();
            }
            return View(passDate);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passDate = await _context.PassDates.FindAsync(id);
            _context.PassDates.Remove(passDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassDateExists(int id)
        {
            return _context.PassDates.Any(e => e.Id == id);
        }
    }
}
