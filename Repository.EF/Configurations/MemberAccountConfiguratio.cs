using Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFRepository.Configurations
{
    public class MemberAccountConfiguratio : IEntityTypeConfiguration<MemberAccount>
    {
        public void Configure(EntityTypeBuilder<MemberAccount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => new { x.UserId, x.CurrencyCode });

            builder
                .HasOne(x => x.Member)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId);

        }
    }
}
