using Domain.Members;
using Infrastructure.Infrastructure;

namespace Domain.Accounts
{
    public class MemberAccount : IAggregateRoot
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Balance { get; set; }
        public Member Member { get; set; }

        public int Key => Id;
    }
}
