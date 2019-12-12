using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Infrastructure
{
    public class Rate
    {
        public string Country { get; set; }
        public decimal IncomeTaxRate { get; set; }
        public decimal SSCRate { get; set; }
        public decimal IncomeTaxThreshold { get; set; }
        public decimal SscThreshold { get; set; }
    }
}
