using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.ProductCategory.DbContextModel
{
    public class ProductCategoryContext : DbContext
    {
        public DbSet<ProductCategoryModel> productCategories { get; set; }

        public ProductCategoryContext(DbContextOptions<ProductCategoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
