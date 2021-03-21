namespace Domain.Accounts
{
    public class MemberAccountAddingClaim
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
