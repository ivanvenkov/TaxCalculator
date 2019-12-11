using System;
using System.Text;

namespace TaxCalculator.Infrastructure
{
    public static class Printer
    {
        public static string PrintResult(Calculation taxCalculation)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Gross Salary: {taxCalculation.GrossSalary:f2} IDR");
            sb.AppendLine($"Social Securtiy Contributions: {taxCalculation.SSCAmount:f2} IDR");
            sb.AppendLine($"Income Tax: {taxCalculation.TaxAmount:f2} IDR");
            sb.AppendLine($"Net Salary: {taxCalculation.NetSalary:f2} IDR");
            Console.WriteLine();
            return sb.ToString();
        }
    }
}
