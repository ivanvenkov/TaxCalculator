using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Contracts
{
    public interface IWriter
    {
        void Write(string message);
    }
}
