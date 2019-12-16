using System;
using TaxCalculator.Contracts;

namespace TaxCalculator.Infrastructure
{
    public class Engine : IEngine
    {
        private readonly ITaxCalculatorService taxCalculatorService;
        private readonly IInputValidator inputValidator;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ITaxCalculatorService taxCalculatorService, IReader reader, IWriter writer, IInputValidator inputValidator)
        {
            this.taxCalculatorService = taxCalculatorService;
            this.reader = reader;
            this.writer = writer;
            this.inputValidator = inputValidator;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    WriteCommand("Please enter the gross salary figure:");
                    var salary = ReadCommand();

                    if (salary.ToLower() == "exit")
                    {
                        WriteCommand("Do you want to exit the program? Y/N");
                        var answer = ReadCommand();
                        if (answer == "y")
                        {
                            return;
                        }
                    }

                    decimal grossSalary = this.inputValidator.ValidateSalary(salary);

                    WriteCommand("Please enter the country:");
                    var country = ReadCommand();

                    this.inputValidator.ValidateCountry(country);
                    var result = this.taxCalculatorService.CalculateNetSalary(grossSalary, country);

                    WriteCommand(result.ToString());
                }
                catch (ArgumentException ex)
                {
                    WriteCommand(ex.Message);
                }
                catch (Exception e)
                {
                    WriteCommand(e.Message);
                }
            }
        }
        private string ReadCommand()
        {
            return this.reader.Read();
        }
        private void WriteCommand(string message)
        {
            this.writer.Write(message);
        }
    }
}
