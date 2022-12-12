using AcoountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagemnt.Infrastructure.DbContextModel
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountModel> accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
