using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация заказа
    /// </summary>
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        /// <summary>
        /// Метод для настройки конфигурации сущности
        /// </summary>
        /// <param name="builder">Тип сущности</param>
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.OrderStatus)
                .IsRequired();

            builder.HasOne(o => o.Client)
                .WithMany(c => c.Orders);

            builder.HasMany(c => c.OrderParts)
                .WithOne(op => op.Order);

            builder.HasOne(o => o.WarehouseContractor)
                .WithMany(w => w.Orders);
        }
    }
}
