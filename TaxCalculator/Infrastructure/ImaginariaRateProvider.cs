using Newtonsoft.Json;
using System.IO;
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


        public decimal IncomeTaxRate { get; set; }
        
        public decimal SSCRate { get; set; }
       
        public decimal IncomeTaxThreshold { get; set; }
        
        public decimal SscThreshold { get; set; }
       
    }
}
