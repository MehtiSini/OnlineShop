using DiscountManagement.Domain.CollegueDiscountAgg;
using DiscountManagement.Domain.CusotmerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EfCore.DbContextModel
{ 
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscountModel> CustomerDiscount { get; set; }
        public DbSet<CollegueDiscountModel> CollegueDiscount { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(DiscountContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
