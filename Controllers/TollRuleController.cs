using Microsoft.AspNetCore.Mvc;
using congestion_tax_calculator.Models;
using System.Linq;

namespace congestion_tax_calculator.Controllers
{
    public class TollRuleController : Controller
    {
        private readonly TaxDbContext _context;

        public TollRuleController(TaxDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            var tollRules = _context.TollRules.ToList();
            return View(tollRules);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TollRule tollRule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tollRule);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tollRule);
        }

        // GET
        public IActionResult Edit(int id)
        {
            var tollRule = _context.TollRules.Find(id);
            if (tollRule == null)
            {
                return NotFound();
            }
            return View(tollRule);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TollRule tollRule)
        {
            if (id != tollRule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(tollRule);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tollRule);
        }

        // GET
        public IActionResult Delete(int id)
        {
            var tollRule = _context.TollRules.Find(id);
            if (tollRule == null)
            {
                return NotFound();
            }
            return View(tollRule);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tollRule = _context.TollRules.Find(id);
            _context.TollRules.Remove(tollRule);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Details(int id)
        {
            var tollRule = _context.TollRules.Find(id);
            if (tollRule == null)
            {
                return NotFound();
            }
            return View(tollRule);
        }
    }
}
