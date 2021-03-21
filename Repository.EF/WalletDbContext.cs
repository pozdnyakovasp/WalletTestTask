using Domain.Accounts;
using Domain.Members;
using Domain.Rates;
using Microsoft.EntityFrameworkCore;

namespace EFRepository
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalletDbContext).Assembly);
            modelBuilder.Entity<MemberAccount>()
                .HasOne(x => x.Member)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Member>()
                .HasMany(x => x.Accounts)
                .WithOne(x => x.Member)
                .HasForeignKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CurrencyRate> Rates { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<MemberAccount> MemberAccounts { get; set; }


    }
}
