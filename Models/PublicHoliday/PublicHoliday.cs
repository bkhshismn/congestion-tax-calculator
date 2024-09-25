using System.ComponentModel.DataAnnotations;

namespace congestion_tax_calculator.Models
{
    public class PublicHoliday
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
