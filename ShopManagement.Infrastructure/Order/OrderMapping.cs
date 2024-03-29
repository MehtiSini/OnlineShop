﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Infrastructure.EfCore.Order
{
    public class OrderMapping : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.ToTable("Orders").HasKey(x => x.Id);
            builder.Property(x => x.IssueTrackingNo).HasMaxLength(8);

            builder.OwnsMany(x => x.Items, navigationBuilder =>
            {
                navigationBuilder.ToTable("OrderItems");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);
            });
        }
    }
}
