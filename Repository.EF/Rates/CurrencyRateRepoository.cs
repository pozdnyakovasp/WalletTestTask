using Domain.Rates;
using System.Collections.Generic;
using System.Linq;

namespace EFRepository
{
    public class CurrencyRateRepoository : ICurrencyRateRepoository
    {
        private readonly WalletDbContext _context;

        public CurrencyRateRepoository(WalletDbContext context)
        {
            _context = context;
        }

        public CurrencyRate Add(CurrencyRate entity)
        {
            return _context.Rates.Add(entity).Entity;
        }

        public void Delete(CurrencyRate entity)
        {
            _context.Rates.Remove(entity);
        }

        public IEnumerable<CurrencyRate> GetAll()
        {
            return _context.Rates.ToArray();
        }

        public CurrencyRate GetBy(string litterCode)
        {
            var value = litterCode?.ToLower().Trim(); ;
            return _context.Rates.FirstOrDefault(x => x.LitterCode.ToLower() == value);
        }

        public CurrencyRate GetBy(int key)
        {
            return _context.Rates.FirstOrDefault(x => x.Id == key);
        }

        public void Update(CurrencyRate entity)
        {
            _context.Rates.Update(entity);
        }
    }
}
