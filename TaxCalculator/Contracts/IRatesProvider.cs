namespace TaxCalculator.Contracts
{
    public interface IRatesProvider
    {
        decimal IncomeTaxRate { get; set; }
        decimal SSCRate { get; set; }
        decimal IncomeTaxThreshold { get; set; }
        decimal SscThreshold { get; set; }
    }
}
