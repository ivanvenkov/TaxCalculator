using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaxCalculator.Contracts;
using TaxCalculator.Models;

namespace TaxCalculator.Infrastructure
{
    public class InputValidator : IInputValidator
    {
        public decimal ValidateSalary(string salary)
        {
            if (string.IsNullOrWhiteSpace(salary))
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }
            decimal grossSalary;

            decimal.TryParse(salary, out grossSalary);

            if (grossSalary <= 0)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }

            return grossSalary;
        }

        public void ValidateCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException("Please provide the name of the country");
            }

            string rates = File.ReadAllText(@"..\..\..\Json\rates.json");

            var ratesProvider = JsonConvert.DeserializeObject<IEnumerable<Rate>>(rates);

            var countries = ratesProvider.Select(r => r.Country).ToList();

            if (!countries.Contains(country))
            {
                throw new ArgumentException("Please note that the country you are looking for does not exist in our database. \r\n");
            }
        }
    }
}
