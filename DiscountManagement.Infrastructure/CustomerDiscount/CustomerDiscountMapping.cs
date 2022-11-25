using DiscountManagement.Domain.CusotmerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EfCore.CustomerDiscount
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscountModel>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscountModel> builder)
        {
            builder.ToTable("CustomerDiscount");
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.DiscountRate).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(250);
        }
    }
}
