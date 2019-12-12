using TaxCalculator.Models;

namespace TaxCalculator.Contracts
{
    public interface IRatesProvider
    {
        Rate GetRates(string country);
    }
}
