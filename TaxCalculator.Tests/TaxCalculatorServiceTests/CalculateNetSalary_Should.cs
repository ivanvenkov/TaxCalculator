using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;
using TaxCalculator.Models;
using TaxCalculator.Services;

namespace TaxCalculator.Tests.TaxCalculatorServiceTests
{
    [TestClass]
    public class CalculateNetSalary_Should
    {
        [TestMethod]
        public void ReturnCorrectNetSalayry_WhenGrossSalaryIsBelowOrEuqalTo1000()
        {
            var grossSalaryMocked = 1000m;
            var countryMocked = "Country";

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
            var countryMocked = "Country";
            var expectedNetSalary = 1001m - 0.25m;

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

            Assert.AreEqual(expectedNetSalary, netSalaryMocked.NetSalary);
        }

        [TestMethod]
        public void ReturnCorrectNetSalayry_WhenGrossSalaryIsAbove3000()
        {
            var grossSalaryMocked = 3001m;
            var countryMocked = "Country";
            var expectedNetSalary = 3001m - 300m - 200.1m;

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

            Assert.AreEqual(expectedNetSalary, netSalaryMocked.NetSalary);
        }
    }
}
