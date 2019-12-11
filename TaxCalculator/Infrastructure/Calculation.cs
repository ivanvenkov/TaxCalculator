using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Infrastructure
{
    public class Calculation
    {
        public Calculation(decimal grossSalary)
        {
            this.GrossSalary = grossSalary;
        }

        public decimal GrossSalary { get; }
        public decimal TaxAmount { get; set; }
        public decimal SSCAmount { get; set; }
        public decimal NetSalary { get; set; }

    }
}
