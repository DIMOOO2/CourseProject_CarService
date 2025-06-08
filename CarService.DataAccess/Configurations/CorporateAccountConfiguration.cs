using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация корпоративного аккаунта
    /// </summary>
    public class CorporateAccountConfiguration : IEntityTypeConfiguration<CorporateAccountEntity>
    {
        /// <summary>
        /// Метод для настройки конфигурации сущности
        /// </summary>
        /// <param name="builder">Тип сущности</param>
        public void Configure(EntityTypeBuilder<CorporateAccountEntity> builder)
        {
            builder.HasKey(c => c.AccountId);

            builder.Property(c => c.LogIn)
                .IsRequired();

            builder.Property(c => c.Password)
                .IsRequired();

            builder.HasOne(c => c.Warehouse)
                .WithOne();
        }
    }
}
