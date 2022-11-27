using InventoryManaement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EfCore.Inventory
{
    public class InventoryMapping : IEntityTypeConfiguration<InventoryModel>
    {
        public void Configure(EntityTypeBuilder<InventoryModel> builder)
        {
            builder.ToTable("Inventory").HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations, modelbuilder =>
            {
                modelbuilder.ToTable("InventoryOperation").HasKey(x => x.Id);
                modelbuilder.Property(x => x.Description).HasMaxLength(1000);
                modelbuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });

        }
    }
}
