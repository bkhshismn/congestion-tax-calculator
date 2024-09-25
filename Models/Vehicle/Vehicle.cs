using System.ComponentModel.DataAnnotations;

namespace congestion_tax_calculator.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public bool IsExempt { get; set; }
        public string LicensePlate { get; set; }
    }
}
