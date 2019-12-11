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
                
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Do you want to exit the program? Y/N");
                    var answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        Environment.Exit(0);
                    }
                }
                
                try
                {
                    var grossSalary = InputValidator.Validate(input);
                    var result = this.taxCalculatorService.CalculateNetSalary(grossSalary);
                    Console.WriteLine(Printer.PrintResult(result));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
