using System;
using TaxCalculator.Contracts;

namespace TaxCalculator.Infrastructure
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
