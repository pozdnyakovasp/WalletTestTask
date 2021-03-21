using Domain.Accounts;
using Domain.Members;
using Domain.Rates;

namespace Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        ICurrencyRateRepoository CurrencyRates { get; }
        IMemberRepository Members { get; }
        IMemberAccountReposotory MemberAccounts { get; }

        void Commit();
    }
}
