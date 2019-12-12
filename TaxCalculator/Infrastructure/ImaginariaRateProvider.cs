using TaxCalculator.Contracts;

namespace TaxCalculator.Infrastructure
{
    public class ImaginariaRateProvider : IRatesProvider
    {
        public decimal IncomeTaxRate { get; set; }

        public decimal SSCRate { get; set; }

        public decimal IncomeTaxThreshold { get; set; }

        public decimal SscThreshold { get; set; }

    }
}
