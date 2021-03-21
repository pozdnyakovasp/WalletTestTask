using Infrastructure.Infrastructure;
using System.Collections.Generic;

namespace Domain.Rates
{
    public interface ICurrencyRateRepoository : IRepository<CurrencyRate>
    {
        CurrencyRate GetBy(string litterCode);
        IEnumerable<CurrencyRate> GetAll();
    }
}
