using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;
using TaxCalculator.Services;

namespace TaxCalculator.Tests.TaxCalculatorServiceTests
{
    [TestClass]
    public class CalculateNetSalary_Should
    {
        [TestMethod]
        public void ReturnCorrectNetSalayry_WhenGrossSalaryIsBelow1000()
        {
            var grossSalaryMocked = 1000m;
                                   

            var ratesProviderMocked = new ImaginariaRateProvider()
            {
                IncomeTaxRate = 0.1m,
                SSCRate = 0.15m,
                IncomeTaxThreshold = 1000m,
                SscThreshold = 3000m
            };

            var sut = new TaxCalculatorService(ratesProviderMocked);
                        
            var netSalaryMocked = sut.CalculateNetSalary(grossSalaryMocked);

            Assert.AreEqual(1000, netSalaryMocked);
        }

    }
}
