using System.ComponentModel.DataAnnotations;

namespace congestion_tax_calculator.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TollRule> TollRules { get; set; } // ارتباط با قوانین عوارض
    }
}
