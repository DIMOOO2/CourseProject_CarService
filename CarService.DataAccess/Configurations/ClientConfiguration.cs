using CarService.Core.Models;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
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