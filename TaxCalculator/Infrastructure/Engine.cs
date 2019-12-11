using System;
using TaxCalculator.Contracts;
using TaxCalculator.Infrastructure;

namespace TaxCalculator.Infrastructure
{
    public class Engine : IEngine
    {
        private readonly ITaxCalculatorService taxCalculatorService;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ITaxCalculatorService taxCalculatorService, IReader reader, IWriter writer)
        {
            this.taxCalculatorService = taxCalculatorService;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                WriteCommand("Please enter the gross salary figure:");
                var input = ReadCommand();

                if (input.ToLower() == "exit")
                {
                    WriteCommand("Do you want to exit the program? Y/N");
                    var answer = ReadCommand().ToLower();
                    if (answer == "y")
                    {
                        Environment.Exit(0);
                    }
                }

                try
                {
                    var grossSalary = InputValidator.Validate(input);
                    var result = this.taxCalculatorService.CalculateNetSalary(grossSalary);
                    WriteCommand(Printer.PrintResult(result));
                }
                catch (ArgumentException ex)
                {

                    WriteCommand(ex.Message);
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
