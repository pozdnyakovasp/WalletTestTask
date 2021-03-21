using Domain.Accounts;
using Domain.Infrastructure;
using Domain.Members;
using Domain.Rates;
using EFRepository.MemberAccounts;
using EFRepository.Members;

namespace EFRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletDbContext _walletDbContext;

        public UnitOfWork(WalletDbContext walletDbContext)
        {
            _walletDbContext = walletDbContext;
        }

        public ICurrencyRateRepoository CurrencyRates => new CurrencyRateRepoository(_walletDbContext);

        public IMemberRepository Members => new MemberRepository(_walletDbContext);

        public IMemberAccountReposotory MemberAccounts => new MemberAccountRepository(_walletDbContext);

        public void Commit()
        {
            _walletDbContext.SaveChanges();
        }
    }
}
