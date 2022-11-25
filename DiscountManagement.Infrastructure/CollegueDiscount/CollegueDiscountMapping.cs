using DiscountManagement.Domain.CollegueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EfCore.CollegueDiscount
{
    public class CollegueDiscountMapping : IEntityTypeConfiguration<CollegueDiscountModel>
    {
        public void Configure(EntityTypeBuilder<CollegueDiscountModel> builder)
        {
            builder.ToTable("CollegueDiscount");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DiscountRate).IsRequired();
        }
    }
}
