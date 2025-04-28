using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class CorporateAccountConfiguration : IEntityTypeConfiguration<CorporateAccountEntity>
    {
        public void Configure(EntityTypeBuilder<CorporateAccountEntity> builder)
        {
            builder.HasKey(c => c.AccountId);

            builder.Property(c => c.LogIn)
                .IsRequired();

            builder.Property(c => c.Password)
                .IsRequired();

            builder.HasOne(c => c.Warehouse)
                .WithOne(w => w.CorporateAccount);
        }
    }
}
