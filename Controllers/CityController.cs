using System.Linq;
using Microsoft.AspNetCore.Mvc;
using congestion_tax_calculator.Models;

namespace congestion_tax_calculator.Controllers
{
    public class CityController : Controller
    {
        private readonly TaxDbContext _context;

        public CityController(TaxDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            var cities = _context.Cities.ToList();
            return View(cities);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {

                _context.Add(city);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

        }

        // GET
        public IActionResult Edit(int id)
        {
            var city = _context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

           
                _context.Update(city);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }

        // GET
        public IActionResult Delete(int id)
        {
            var city = _context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET
        public IActionResult Details(int id)
        {
            var city = _context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }
    }
}
