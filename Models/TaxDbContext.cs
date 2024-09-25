using congestion_tax_calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator.Models
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext(DbContextOptions<TaxDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<PassDate> PassDates { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TollRule> TollRules { get; set; }
    }
}
