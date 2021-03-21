using Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Api.Models.Members
{
    public class MemberAddMoneyQueryModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; }

        public MemberAccountAddingClaim ToClaim()
        {
            return new MemberAccountAddingClaim
            {
                Amount = Amount,
                Currency = Currency.ToLower(),
                UserId = UserId
            };
        }
    }
}
