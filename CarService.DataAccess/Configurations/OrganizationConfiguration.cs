using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<OrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
        {
            builder.HasKey(o => o.OrganizationId);

            builder.Property(o => o.TitleOrganization)
                .IsRequired();

            builder.Property(o => o.TIN)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(o => o.Address)
                .IsRequired();

            builder.Property(o => o.City)
                .IsRequired();

            builder.HasMany(o => o.Clients)
                .WithOne(o => o.Organization);
        }
    }
}
