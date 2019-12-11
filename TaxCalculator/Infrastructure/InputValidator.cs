using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Infrastructure
{
    public static class InputValidator
    {
        public static decimal ValidateInput(string input)
        {
            //input = Console.ReadLine().ToLower();
            if (input == null)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }
            decimal grossSalary;

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Do you want to exit the program? Y/N");
                var answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    Environment.Exit(0);
                }
            }

            bool getCorrrectSalary = decimal.TryParse(input, out grossSalary);

            if (grossSalary <= 0)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }

            return grossSalary;
        }
    }
}
