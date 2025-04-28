using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<WarehouseEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
        {
            builder.HasKey(b => b.WarehouseId);

            builder.Property(b => b.Title)
                .IsRequired();

            builder.Property(b => b.Address)
                            .IsRequired();

            builder.Property(b => b.City)
                .IsRequired();

            builder.HasOne(w => w.CorporateAccount)
                .WithOne(a => a.Warehouse)
                .IsRequired();

        }
    }
}
