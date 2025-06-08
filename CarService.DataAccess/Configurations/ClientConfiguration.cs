using CarService.Core.Models;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация клиента
    /// </summary>
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        /// <summary>
        /// Метод для настройки конфигурации сущности
        /// </summary>
        /// <param name="builder">Тип сущности</param>
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.FirstName)
                .IsRequired();
            
            builder.Property(c => c.LastName)
                .IsRequired();
            
            builder.Property(c => c.MiddleName);
            
            builder.Property(c => c.PhoneNumber)
                .IsRequired(); 
            
            builder.Property(c => c.Email)
                .IsRequired();
            
            builder.Property(c => c.City)
                .IsRequired();

            builder.HasOne(c => c.Organization)
                .WithMany(o => o.Clients);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Client);
        }
    }
}