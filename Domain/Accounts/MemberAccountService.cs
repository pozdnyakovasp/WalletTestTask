using Domain.Infrastructure;
using System;
using System.Linq;

namespace Domain.Accounts
{
    public class MemberAccountService : IMemberAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(MemberAccountAddingClaim claim)
        {
            var accounts = _unitOfWork.MemberAccounts.GetByUser(claim.UserId);
            var account = accounts.FirstOrDefault(x => x.CurrencyCode == claim.Currency);
            if (account == null)
            {
                var newAccount = CreateAccount(claim);
                _unitOfWork.MemberAccounts.Add(newAccount);
                _unitOfWork.Commit();
                return;
            }
            account.Balance += claim.Amount;
            _unitOfWork.MemberAccounts.Update(account);
            _unitOfWork.Commit();
        }

        public void WithdrawMoney(MemberAccountAddingClaim claim)
        {
            var accounts = _unitOfWork.MemberAccounts.GetByUser(claim.UserId);
            var account = accounts.FirstOrDefault(x => x.CurrencyCode == claim.Currency);
            if (account == null)
            {
                throw new InvalidOperationException("Account not excists.");
            }

            if (account.Balance - claim.Amount < 0)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            account.Balance -= claim.Amount;
            _unitOfWork.MemberAccounts.Update(account);
            _unitOfWork.Commit();
        }

        private MemberAccount CreateAccount(MemberAccountAddingClaim claim)
        {
            return new MemberAccount
            {
                Balance = claim.Amount,
                CurrencyCode = claim.Currency,
                UserId = claim.UserId
            };
        }
    }
}
