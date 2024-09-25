using System.ComponentModel.DataAnnotations;

namespace congestion_tax_calculator.Models
{
    public class TollRule
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public decimal MaxDailyTax { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Amount { get; set; }

        public virtual City City { get; set; } 
    }
}
