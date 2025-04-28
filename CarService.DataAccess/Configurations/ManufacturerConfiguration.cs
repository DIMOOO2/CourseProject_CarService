using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            builder.HasKey(m => m.ManufacturerId);

            builder.Property(m => m.ManufacturerName);

            builder.Property(m => m.ContactInfo);

            builder.HasMany(m => m.AutoParts)
                .WithOne(a => a.Manufacturer);
        }
    }
}
