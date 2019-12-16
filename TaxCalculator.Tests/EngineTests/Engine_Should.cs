using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;

namespace TaxCalculator.Tests.TaxCalculatorServiceTests
{
    [TestClass]
    public class Engine_Should
    {
        [DataTestMethod]
        [DataRow("EXIT")]
        [DataRow("exit")]
        public void QuitsEngineExecution_WhenExitIsInput(string input)
        {

            var taxServiceMock = new Mock<ITaxCalculatorService>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var inputValidatorMock = new Mock<IInputValidator>();

            readerMock.SetupSequence(s => s.Read())
                .Returns(input)
                .Returns("y");

            var sut = new Engine(taxServiceMock.Object, readerMock.Object, writerMock.Object, inputValidatorMock.Object);

            sut.Run();

            readerMock.Verify(r => r.Read(), Times.Exactly(2));
            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Please enter the gross salary figure:")), Times.Once);
            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Do you want to exit the program? Y/N")), Times.Once);
        }

        [DataTestMethod]
        [DataRow("-1")]
        [DataRow("0")]
        [DataRow("test")]
        [DataRow(" ")]
        public void AsksForCorrectSalary_WhenWrongSalaryIsInput(string salary)
        {
            var taxServiceMock = new Mock<ITaxCalculatorService>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var inputValidatorMock = new Mock<IInputValidator>();

            readerMock.SetupSequence(s => s.Read())
                .Returns(salary)
                .Returns("exit")
                .Returns("y");

            inputValidatorMock.Setup(x => x.ValidateSalary(salary)).Throws<ArgumentException>();

            var sut = new Engine(taxServiceMock.Object, readerMock.Object, writerMock.Object, inputValidatorMock.Object);

            sut.Run();

            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Please enter the gross salary figure:")), Times.Exactly(2));
            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Do you want to exit the program? Y/N")), Times.Once);
        }

        [TestMethod]
        public void AsksForCountry_WhenCorrectSalaryIsInput()
        {
            var taxServiceMock = new Mock<ITaxCalculatorService>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var inputValidatorMock = new Mock<IInputValidator>();

            readerMock.SetupSequence(s => s.Read())
                .Returns("1000")
                .Returns("Test")
                .Returns("exit")
                .Returns("y");

            inputValidatorMock.Setup(x => x.ValidateSalary("1000")).Returns(1000m);

            var sut = new Engine(taxServiceMock.Object, readerMock.Object, writerMock.Object, inputValidatorMock.Object);

            sut.Run();

            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Please enter the gross salary figure:")), Times.Exactly(2));
            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Do you want to exit the program? Y/N")), Times.Once);
            writerMock.Verify(w => w.Write(It.Is<string>(wr => wr == "Please enter the country:")), Times.Once);
        }
    }
}