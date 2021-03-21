using Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFRepository.Configurations
{
    public class MemberConfiguratio : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder
                .HasMany(x => x.Accounts)
                .WithOne(x => x.Member)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(x => x.UserId);
        }
    }
}
