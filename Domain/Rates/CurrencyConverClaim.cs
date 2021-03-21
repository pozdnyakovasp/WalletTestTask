namespace Domain.Rates
{
    public class CurrencyConverClaim
    {
        public int UserId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }
}
