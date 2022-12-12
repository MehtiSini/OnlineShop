using AcoountManagement.Domain.AccountAgg;
using AcoountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastrucure.EfCore.DbContextModel
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountModel> accounts { get; set; }
        public DbSet<RoleModel> roles { get; set; }

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
