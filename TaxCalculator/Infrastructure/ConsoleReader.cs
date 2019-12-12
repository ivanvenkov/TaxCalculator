using System;
using System.Globalization;
using TaxCalculator.Contracts;

namespace TaxCalculator.Infrastructure
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine().ToLower();
        }
    }
}
