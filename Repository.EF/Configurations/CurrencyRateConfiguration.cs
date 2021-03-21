using Domain.Rates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFRepository.Configurations
{
    public class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Rate).HasPrecision(10, 5);

            builder.HasIndex(x => x.LitterCode)
                .IncludeProperties(x => new { x.Rate, x.ChangeDate });
        }
    }
}
