using Infrastructure.Infrastructure;
using System;

namespace Domain.Rates
{
    public class CurrencyRate : IAggregateRoot
    {
        public int Id { get; set; }

        public decimal Rate { get; set; }
        public string LitterCode { get; set; }
        public DateTime ChangeDate { get; set; }

        public int Key => Id;
    }
}
