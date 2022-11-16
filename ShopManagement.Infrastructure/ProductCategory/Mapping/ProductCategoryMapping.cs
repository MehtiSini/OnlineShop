using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.ProductCategory.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategoryModel>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryModel> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(255);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PicturePath).HasMaxLength(1000);
            builder.Property(x => x.KeyWords).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();
        }
    }
}
