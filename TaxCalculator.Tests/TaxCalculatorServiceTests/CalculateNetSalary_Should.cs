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
            var countryMocked = "Brazil";

            var rateMocked = new Rate()
            {
                Country = countryMocked,
                IncomeTaxRate = 0.1m,
                SSCRate = 0.15m,
                IncomeTaxThreshold = 1000m,
                SscThreshold = 3000m
            };

            var ratesProvider = new Mock<IRatesProvider>();
                ratesProvider.Setup(x => x.GetRates(countryMocked)).Returns(rateMocked);

            var sut = new TaxCalculatorService(ratesProvider.Object);
                        
            var netSalaryMocked = sut.CalculateNetSalary(grossSalaryMocked, countryMocked);

            Assert.AreEqual(1000, netSalaryMocked.NetSalary);
        }

        [TestMethod]
        public void ReturnCorrectNetSalayry_WhenGrossSalaryIsBetween1000And3000()
        {
            var grossSalaryMocked = 1001m;
            var countryMocked = "Brazil";

            var rateMocked = new Rate()
            {
                Country = countryMocked,
                IncomeTaxRate = 0.1m,
                SSCRate = 0.15m,
                IncomeTaxThreshold = 1000m,
                SscThreshold = 3000m
            };

            var ratesProvider = new Mock<IRatesProvider>();
            ratesProvider.Setup(x => x.GetRates(countryMocked)).Returns(rateMocked);

            var sut = new TaxCalculatorService(ratesProvider.Object);

            var netSalaryMocked = sut.CalculateNetSalary(grossSalaryMocked, countryMocked);

            Assert.AreEqual(1001m-0.25m, netSalaryMocked.NetSalary);
        }

        [TestMethod]
        public void ReturnCorrectNetSalayry_WhenGrossSalaryIsAbove3000()
        {
            var grossSalaryMocked = 3400m;
            var countryMocked = "Brazil";

            var rateMocked = new Rate()
            {
                Country = countryMocked,
                IncomeTaxRate = 0.1m,
                SSCRate = 0.15m,
                IncomeTaxThreshold = 1000m,
                SscThreshold = 3000m
            };

            var ratesProvider = new Mock<IRatesProvider>();
            ratesProvider.Setup(x => x.GetRates(countryMocked)).Returns(rateMocked);

            var sut = new TaxCalculatorService(ratesProvider.Object);

            var netSalaryMocked = sut.CalculateNetSalary(grossSalaryMocked, countryMocked);

            Assert.AreEqual(2860, netSalaryMocked.NetSalary);
        }

    }
}
