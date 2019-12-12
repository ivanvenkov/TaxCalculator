using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaxCalculator.Contracts;
using TaxCalculator.Models;

namespace TaxCalculator.Infrastructure
{
    public class RatesProvider : IRatesProvider
    {
        public Rate GetRates(string country)
        {
            var rate = LoadJson().SingleOrDefault(x => x.Country == country);
            return rate;
        }

        private IEnumerable<Rate> LoadJson()
        {
            string rates = File.ReadAllText(@"..\..\..\Json\rates.json");

            var ratesProvider = JsonConvert.DeserializeObject<IEnumerable<Rate>>(rates);

            return ratesProvider;
        }
    }
}
