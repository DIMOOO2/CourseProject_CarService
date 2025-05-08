using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class AutoPartConfiguration : IEntityTypeConfiguration<AutoPartEntity>
    {
        public void Configure(EntityTypeBuilder<AutoPartEntity> builder)
        {
            builder.HasKey(a => a.AutoPartId);

            builder.Property(a => a.AutoPartName)
                .IsRequired();

            builder.Property(a => a.PartNumber)
                .HasMaxLength(6)
                .IsRequired();
            
            builder.Property(a => a.Price)
                .IsRequired();
            
            builder.Property(a => a.StockAmount)
                .IsRequired();

            builder.HasOne(a => a.Manufacturer)
                .WithMany(m => m.AutoParts)
                .IsRequired();

            builder.HasOne(a => a.Warehouse)
                .WithMany(w => w.AutoParts);
        }
    }
}