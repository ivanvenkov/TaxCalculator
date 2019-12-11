using System;

namespace TaxCalculator.Infrastructure
{
    public static class InputValidator
    {
        public static decimal Validate(string input)
        {
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
