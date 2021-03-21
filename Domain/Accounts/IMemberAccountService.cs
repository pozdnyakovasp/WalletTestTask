using Domain.Members;

namespace Domain.Accounts
{
    public interface IMemberAccountService
    {
        void AddOrUpdate(MemberAccountAddingClaim claim);
        void WithdrawMoney(MemberAccountAddingClaim claim);
    }
}
