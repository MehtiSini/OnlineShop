using AcoountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastrucure.EfCore.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.ToTable("Role").HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);


            builder.OwnsMany(x => x.Permissions, navigationBuilder =>
                {
                    navigationBuilder.HasKey(x => x.Id);
                    navigationBuilder.ToTable("RolePermissions");
                    navigationBuilder.Ignore(x => x.Name);
                    navigationBuilder.WithOwner(X => X.Role);
                });
        }
    }
}
