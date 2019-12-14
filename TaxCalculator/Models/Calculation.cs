using System;
using System.Text;

namespace TaxCalculator.Models
{
    public class Calculation
    {
        public Calculation()
        {

        }
        public Calculation(decimal grossSalary)
        {
            this.GrossSalary = grossSalary;
        }
        public decimal GrossSalary { get; }
        public decimal TaxAmount { get; set; }
        public decimal SSCAmount { get; set; }
        public decimal NetSalary { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Gross Salary: {GrossSalary:f2} IDR");
            sb.AppendLine($"Social Securtiy Contributions: {SSCAmount:f2} IDR");
            sb.AppendLine($"Income Tax: {TaxAmount:f2} IDR");
            sb.AppendLine($"Net Salary: {NetSalary:f2} IDR");
            Console.WriteLine();
            return sb.ToString();
        }
    }
}
