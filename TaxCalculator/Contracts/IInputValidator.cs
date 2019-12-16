using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Contracts
{
    public interface IInputValidator
    {
        decimal ValidateSalary(string salary);
        void ValidateCountry(string country);
    }
}
