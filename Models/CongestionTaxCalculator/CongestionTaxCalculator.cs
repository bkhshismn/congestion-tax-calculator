
namespace congestion_tax_calculator.Models
{
    public class CongestionTaxCalculator
    {
        private readonly TaxDbContext _context;

        public CongestionTaxCalculator(TaxDbContext context)
        {
            _context = context;
        }

        public int CalculateTax(int vehicleId, List<DateTime> dates, int cityId)
        {
            var vehicle = _context.Vehicles.Find(vehicleId);
            var tollRules = _context.TollRules.Where(tr => tr.CityId == cityId).ToList();

            if (vehicle == null || vehicle.IsExempt || dates == null || !dates.Any() || !tollRules.Any())
            {
                return 0;
            }

            var publicHolidays = _context.PublicHolidays.Select(h => h.Date.Date).ToList();
            var dailyTax = new Dictionary<DateTime, int>();

            foreach (var date in dates.OrderBy(d => d))
            {
                if (IsTaxFreeDate(date, publicHolidays))
                    continue;

                var maxFee = 0;

                foreach (var rule in tollRules)
                {
                    if (date.TimeOfDay >= rule.StartTime && date.TimeOfDay <= rule.EndTime)
                    {
                        maxFee = Math.Max(maxFee, rule.Amount);
                    }
                }

                var hourWindow = dates.Where(d => (date - d).TotalMinutes <= 60);
                var maxInWindow = hourWindow.Max(d => maxFee);

                dailyTax[date.Date] = (int)(dailyTax.ContainsKey(date.Date)
                    ? Math.Min(dailyTax[date.Date] + maxInWindow, tollRules.Max(tr => tr.MaxDailyTax))
                    : maxInWindow);
            }

            return dailyTax.Values.Sum();
        }

        private bool IsTaxFreeDate(DateTime date, List<DateTime> publicHolidays)
        {   
            return date.DayOfWeek == DayOfWeek.Saturday ||
                   date.DayOfWeek == DayOfWeek.Sunday ||
                   publicHolidays.Contains(date.Date) ||
                   IsDayBeforePublicHoliday(date);
        }

        private bool IsDayBeforePublicHoliday(DateTime date)
        {
            return _context.PublicHolidays.Any(h => h.Date == date.AddDays(1));
        }
    }
}
