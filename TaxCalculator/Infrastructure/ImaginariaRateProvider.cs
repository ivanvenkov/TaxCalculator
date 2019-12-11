using TaxCalculator.Contracts;

namespace TaxCalculator.Infrastructure
{
    public class ImaginariaRateProvider : IRatesProvider
    {
        private decimal incomeTaxRate;
        private decimal sscRate;
        private decimal incomeTaxThreshold;
        private decimal sscThreshold;

        public ImaginariaRateProvider()
        {
            this.IncomeTaxRate = incomeTaxRate;
            this.IncomeTaxThreshold = incomeTaxThreshold;
            this.SSCRate = sscRate;
            this.SscThreshold = sscThreshold;
        }

        public decimal IncomeTaxRate
        {
            get => this.incomeTaxRate;
            set { incomeTaxRate = 0.1m; }
        }
        public decimal SSCRate
        {
            get => this.sscRate;
            set { sscRate = 0.15m; }
        }

        public decimal IncomeTaxThreshold
        {
            get => this.incomeTaxThreshold;
            set { incomeTaxThreshold = 1000m; }
        }
        public decimal SscThreshold
        {
            get => this.sscThreshold;
            set { sscThreshold = 3000m; }
        }
    }
}
