using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация склада
    /// </summary>
    public class WarehouseConfiguration : IEntityTypeConfiguration<WarehouseEntity>
    {
        /// <summary>
        /// Метод для настройки конфигурации сущности
        /// </summary>
        /// <param name="builder">Тип сущности</param>
        public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
        {
            builder.HasKey(b => b.WarehouseId);

            builder.Property(b => b.Title)
                .IsRequired();

            builder.Property(b => b.Address)
                            .IsRequired();

            builder.Property(b => b.City)
                .IsRequired();
        }
    }
}
