using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using congestion_tax_calculator.Models;

namespace congestion_tax_calculator.Controllers
{
    public class TaxController : Controller
    {
        private readonly TaxDbContext _context; 
        private readonly CongestionTaxCalculator _taxCalculator;

        public TaxController(TaxDbContext taxDbContext, CongestionTaxCalculator congestionTaxCalculator)
        {
            _context = taxDbContext; 
            _taxCalculator = congestionTaxCalculator; 
        }

        public ActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList(); 
            var cities = _context.Cities.ToList();
            ViewBag.Vehicles = vehicles;
            ViewBag.Cities = cities;
            return View(); 
        }


        [HttpPost]
        public ActionResult CalculateTax(int vehicleId, List<string> dateStrings, int cityId)
        {

            var dates = dateStrings.Select(dateStr => DateTime.Parse(dateStr)).ToList();


            int totalTax = _taxCalculator.CalculateTax(vehicleId, dates, cityId);

            ViewBag.TotalTax = totalTax;
            ViewBag.Vehicles = _context.Vehicles.ToList();
            ViewBag.Cities = _context.Cities.ToList(); 
            return View("Index");
        }
    }
}
