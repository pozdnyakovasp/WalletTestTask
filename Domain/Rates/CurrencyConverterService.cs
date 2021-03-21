using Domain.Infrastructure;
using System;
using System.Collections.Generic;

namespace Domain.Rates
{
    public class CurrencyConverterService : ICurrencyRateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyConverterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal CalculateConvert(string from, string to, decimal sourceAmount)
        {
            var result = CalculateConvertedAmount(from, to, sourceAmount);
            return result;
        }

        public void Convert(CurrencyConverClaim claim)
        {
            var accountFrom = _unitOfWork.MemberAccounts.GetByUser(claim.UserId, claim.From);
            if (accountFrom == null)
            {
                throw new InvalidOperationException("Source account not exists.");
            }

            if (accountFrom.Balance - claim.Amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            var amountInTargetCurrency = CalculateConvertedAmount(claim.From, claim.To, claim.Amount);
            var accountTo = _unitOfWork.MemberAccounts.GetByUser(claim.UserId, claim.To);
            if (accountTo == null)
            {
                accountTo = new Accounts.MemberAccount
                {
                    Balance = amountInTargetCurrency,
                    CurrencyCode = claim.To,
                    UserId = claim.UserId,
                };
                _unitOfWork.MemberAccounts.Add(accountTo);
            }
            else
            {
                accountTo.Balance += amountInTargetCurrency;
                _unitOfWork.MemberAccounts.Update(accountTo);
            }

            accountFrom.Balance -= claim.Amount;

            _unitOfWork.MemberAccounts.Update(accountFrom);
            _unitOfWork.Commit();
        }

        public IEnumerable<CurrencyRate> GetRates()
        {
            return _unitOfWork.CurrencyRates.GetAll();
        }

        private decimal CalculateConvertedAmount(string from, string to, decimal sourceAmount)
        {
            var repo = _unitOfWork.CurrencyRates;
            var rateFrom = repo.GetBy(from);
            var rateTo = repo.GetBy(to);

            var amountInEuro = (sourceAmount / (rateFrom?.Rate ?? 1));
            var amountInTargetCurrency = (rateTo?.Rate ?? 1) * amountInEuro;

            return amountInTargetCurrency;
        }
    }
}
