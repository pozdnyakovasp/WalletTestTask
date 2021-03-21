using Domain.Rates;
using System.ComponentModel.DataAnnotations;

namespace Wallet.Api.Models.Converter
{
    public class ConvertQueryModel
    {
        [Required]
        public int UserId { get; set; }
        [Required, MinLength(3), MaxLength(3)]
        public string From { get; set; }
        [Required, MinLength(3), MaxLength(3)]
        public string To { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public CurrencyConverClaim ToClaim()
        {
            return new CurrencyConverClaim
            {
                Amount = Amount,
                From = From.ToLower(),
                To = To.ToLower(),
                UserId = UserId
            };
        }
    }
}
