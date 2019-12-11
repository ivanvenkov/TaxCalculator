using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Infrastructure
{
    public static class Printer
    {
        public static void PrintResult(Calculation taxCalculation)
        {
            //StringBuilder sb = new StringBuilder();


            //sb.AppendLine($"Gross Salary: {grossSalary:f2} IDR");
            //sb.AppendLine($"Social Securtiy Contributions: {sscAmount:f2} IDR");
            //sb.AppendLine($"Income Tax: {taxAmount:f2} IDR");
            //sb.AppendLine($"Net Salary: {netSalary:f2} IDR");

            //return sb.ToString();

            Console.WriteLine($"Gross Salary: {taxCalculation.GrossSalary:f2} IDR");
            Console.WriteLine($"Social Securtiy Contributions: {taxCalculation.SSCAmount:f2} IDR");
            Console.WriteLine($"Income Tax: {taxCalculation.TaxAmount:f2} IDR");
            Console.WriteLine($"Net Salary: {taxCalculation.NetSalary:f2} IDR");
            Console.WriteLine();
        }
    }
}
