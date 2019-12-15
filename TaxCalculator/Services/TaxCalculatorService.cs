using TaxCalculator.Contracts;
using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private IRatesProvider ratesProvider;

        public TaxCalculatorService(IRatesProvider ratesProvider)
        {
            this.ratesProvider = ratesProvider;
        }

        public Calculation CalculateNetSalary(decimal grossSalary, string country)
        {
            decimal sscAmount;
            var rate = this.ratesProvider.GetRates(country);

            var taxCalculation = new Calculation(grossSalary);

            if (grossSalary <= rate.IncomeTaxThreshold)
            {
                taxCalculation.NetSalary = grossSalary;
            }
            else
            {
                if (grossSalary <= rate.SscThreshold)
                {
                    sscAmount = (grossSalary - rate.IncomeTaxThreshold) * rate.SSCRate;
                }
                else
                {
                    sscAmount = (rate.SscThreshold - rate.IncomeTaxThreshold) * rate.SSCRate;
                }

                taxCalculation.SSCAmount = sscAmount;
                taxCalculation.TaxAmount = (grossSalary - rate.IncomeTaxThreshold) * rate.IncomeTaxRate;
                taxCalculation.NetSalary = grossSalary - sscAmount - taxCalculation.TaxAmount;
            }

            return taxCalculation;
        }
    }
}
