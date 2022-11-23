using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EfCore.Slide
{
    public class SlideMapping : IEntityTypeConfiguration<SlideModel>
    {
        public void Configure(EntityTypeBuilder<SlideModel> builder)
        {
            builder.ToTable("Slide");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.PictureTitle).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PicturePath).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.BtnText).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Link).HasMaxLength(250).IsRequired();

        }
    }
}
