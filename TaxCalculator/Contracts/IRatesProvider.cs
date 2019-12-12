using System.Collections.Generic;
using TaxCalculator.Infrastructure;

namespace TaxCalculator.Contracts
{
    public interface IRatesProvider
    {
        Rate GetRates(string country);
    }
}
