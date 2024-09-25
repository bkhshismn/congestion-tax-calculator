using System.ComponentModel.DataAnnotations;

namespace congestion_tax_calculator.Models
{
    public class PassDate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; } // ارتباط با وسیله نقلیه
    }
}
