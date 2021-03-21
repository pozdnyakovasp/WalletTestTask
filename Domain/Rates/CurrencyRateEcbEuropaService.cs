using Domain.Infrastructure;
using Protocols.EcbEuropa;
using System;
using System.Threading.Tasks;

namespace Domain.Rates
{
    public class CurrencyRateEcbEuropaService : ICurrencyRateEcbEuropaService
    {
        private readonly IEcbEuropaProtocol _ecbEuropaProtocol;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyRateEcbEuropaService(IEcbEuropaProtocol ecbEuropaProtocol, IUnitOfWork unitOfWork)
        {
            _ecbEuropaProtocol = ecbEuropaProtocol;
            _unitOfWork = unitOfWork;
        }

        public async Task Update()
        {
            var rates = await _ecbEuropaProtocol.GetRates();
            var repo = _unitOfWork.CurrencyRates;

            foreach (var rate in rates.Cube.Cube.Rates)
            {

                var dbRate = repo.GetBy(rate.CurrencyName);
                if (dbRate == null)
                {
                    dbRate = new CurrencyRate
                    {
                        ChangeDate = DateTime.Now,
                        LitterCode = rate.CurrencyName,
                        Rate = rate.Rate
                    };
                    _unitOfWork.CurrencyRates.Add(dbRate);
                    continue;
                }

                dbRate.Rate = rate.Rate;
                dbRate.ChangeDate = DateTime.Now;
                _unitOfWork.CurrencyRates.Update(dbRate);
            }
            _unitOfWork.Commit();
        }
    }
}
