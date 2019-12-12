using TaxCalculator.Models;

namespace TaxCalculator.Contracts
{
    public interface ITaxCalculatorService
    {
        Calculation CalculateNetSalary(decimal grossSalary, string country);
    }
}
