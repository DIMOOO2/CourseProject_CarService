using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация запчасти в заказе
    /// </summary>
    public class OrderPartConfiguration : IEntityTypeConfiguration<OrderPartEntity>
    {
        /// <summary>
        /// Метод для настройки конфигурации сущности
        /// </summary>
        /// <param name="builder">Тип сущности</param>
        public void Configure(EntityTypeBuilder<OrderPartEntity> builder)
        {
            builder.HasKey(op => op.OrderedPartId);

            builder.Property(op => op.Amount);

            builder.HasOne(op => op.Order)
                .WithMany(o => o.OrderParts);

            builder.HasOne(op => op.AutoPart)
                .WithOne();

            builder.HasOne(op => op.DepartureWarehouse)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
