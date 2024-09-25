namespace congestion_tax_calculator.Models
{
    public class TaxViewModel
    {
        public int VehicleId { get; set; }
        public List<DateTime> Dates { get; set; }
        public int CityId { get; set; }
        public int TotalTax { get; set; }
    }
}
