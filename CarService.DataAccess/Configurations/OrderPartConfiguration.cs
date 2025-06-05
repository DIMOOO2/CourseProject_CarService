using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class OrderPartConfiguration : IEntityTypeConfiguration<OrderPartEntity>
    {
        public void Configure(EntityTypeBuilder<OrderPartEntity> builder)
        {
            builder.HasKey(op => op.OrderedPartId);

            builder.Property(op => op.Amount);

            builder.HasOne(op => op.Order)
                .WithMany(o => o.OrderParts);

            builder.HasOne(op => op.AutoPart)
                .WithMany();

            builder.HasOne(op => op.DepartureWarehouse)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
