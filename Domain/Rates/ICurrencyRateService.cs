using System.Collections.Generic;

namespace Domain.Rates
{
    public interface ICurrencyRateService
    {
        decimal CalculateConvert(string from, string to, decimal sourceAmount);
        void Convert(CurrencyConverClaim claim);
        IEnumerable<CurrencyRate> GetRates();

    }
}
