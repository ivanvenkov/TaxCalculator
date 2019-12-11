using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;

namespace TaxCalculator
{
    public class Engine
    {
        private readonly ITaxCalculatorService taxCalculatorService;

        public Engine(ITaxCalculatorService taxCalculatorService)
        {
            this.taxCalculatorService = taxCalculatorService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("Please enter the gross salary figure:");
                var input = Console.ReadLine();
                //var grossSalary = InputValidator.ValidateInput(input);

                try
                {
                    var grossSalary = InputValidator.ValidateInput(input);
                    var res = this.taxCalculatorService.CalculateNetSalary(grossSalary);
                    Printer.PrintResult(res);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
