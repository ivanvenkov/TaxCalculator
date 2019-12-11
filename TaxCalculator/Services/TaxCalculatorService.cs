using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;

namespace TaxCalculator.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private IRatesProvider ratesProvider;

        public TaxCalculatorService(IRatesProvider ratesProvider)
        {
            this.ratesProvider = ratesProvider;
        }

        public Calculation CalculateNetSalary(decimal grossSalary)
        {
            decimal sscAmount;

            var taxCalculation = new Calculation(grossSalary);

            if (grossSalary <= 1000)
            {
                taxCalculation.NetSalary = grossSalary;
            }
            else
            {
                if (grossSalary > this.ratesProvider.IncomeTaxThreshold && grossSalary <= this.ratesProvider.SscThreshold)
                {
                    sscAmount = (grossSalary - this.ratesProvider.IncomeTaxThreshold) * this.ratesProvider.SSCRate;
                }
                else
                {
                    sscAmount = (this.ratesProvider.SscThreshold - this.ratesProvider.IncomeTaxThreshold) * this.ratesProvider.SSCRate;
                }

                taxCalculation.SSCAmount = sscAmount;
                taxCalculation.TaxAmount = (grossSalary - this.ratesProvider.IncomeTaxThreshold) * this.ratesProvider.IncomeTaxRate;
                taxCalculation.NetSalary = grossSalary - sscAmount - taxCalculation.TaxAmount;
            }

            return taxCalculation;
        }
    }
}
