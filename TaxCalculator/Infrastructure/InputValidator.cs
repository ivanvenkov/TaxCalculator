using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TaxCalculator.Infrastructure
{
    public static class InputValidator
    {
        public static decimal ValidateSalary(string salary)
        {
            if (salary == null)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }
            decimal grossSalary;

            bool getCorrrectSalary = decimal.TryParse(salary, out grossSalary);

            if (grossSalary <= 0)
            {
                throw new ArgumentException("Please provide a non-negative gross salary figure or exit the program");
            }

            return grossSalary;
        }

        public static string ValidateCountry(string country)
        {
            if (country == null)
            {
                throw new ArgumentException("Please provide the name of the country");
            }
            
            var listOfCountries = new List<string>();

            string rates = File.ReadAllText(@"..\..\..\Json\rates.json");

            var ratesProvider = JsonConvert.DeserializeObject<IEnumerable<Rate>>(rates);

            foreach (var rate in ratesProvider)
            {
                listOfCountries.Add(rate.Country);
            }

            if (!listOfCountries.Contains(country))
            {
                throw new ArgumentException("Please note that the country you are looking for does not exist in our database. \r\n");
            }

            return country;
        }
    }
}
