using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.ProductCategory.DbContextModel
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategoryModel> productCategories { get; set; }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<ProductPictureModel> productPictures { get; set; }
        public DbSet<SlideModel> slides { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ShopContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
