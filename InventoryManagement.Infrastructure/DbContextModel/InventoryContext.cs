using InventoryManaement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EfCore.DbContextModel
{
    public class InventoryContext : DbContext
    {
        public DbSet<InventoryModel> Inventories { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
