using TaxCalculator.Infrastructure;

namespace TaxCalculator.Contracts
{
    public interface ITaxCalculatorService
    {
        Calculation CalculateNetSalary(decimal grossSalary);
    }
}
