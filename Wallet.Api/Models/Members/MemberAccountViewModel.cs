using Domain.Accounts;

namespace Wallet.Api.Models.Members
{
    public class MemberAccountViewModel
    {
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public static MemberAccountViewModel Create(MemberAccount account)
        {
            return new MemberAccountViewModel
            {
                Balance = account.Balance,
                Currency = account.CurrencyCode,
            };
        }
    }
}
