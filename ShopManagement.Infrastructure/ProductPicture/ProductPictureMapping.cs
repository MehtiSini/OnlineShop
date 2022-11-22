using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EfCore.ProductPicture
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPictureModel>
    {
        public void Configure(EntityTypeBuilder<ProductPictureModel> builder)
        {
            builder.ToTable("ProductPicture");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PictureTitle).HasMaxLength(255);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PicturePath).HasMaxLength(1000);

            builder.HasOne(x => x.Product).WithMany(x => x.Pictures).HasForeignKey(x => x.ProductId);
        }
    }
}
