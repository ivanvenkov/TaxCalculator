using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Infrastructure
{
    public static class InputValidator
    {
        public static decimal Validate(string input)
        {
            //input = Console.ReadLine().ToLower();
            if (input == null)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }
            decimal grossSalary;

            
            bool getCorrrectSalary = decimal.TryParse(input, out grossSalary);

            if (grossSalary <= 0)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }

            return grossSalary;
        }
    }
}
