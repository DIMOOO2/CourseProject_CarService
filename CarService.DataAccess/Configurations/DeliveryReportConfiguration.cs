using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarService.DataAccess.Configurations
{
    public class DeliveryReportConfiguration : IEntityTypeConfiguration<DeliveryReportEntity>
    {
        public void Configure(EntityTypeBuilder<DeliveryReportEntity> builder)
        {
            builder.HasKey(dr => dr.ReportId);

            builder.Property(dr => dr.CreateDate)
                .IsRequired();

            builder.Property(dr => dr.ReportFile)
                .IsRequired();

            builder.HasOne(dr => dr.WarehouseCreator)
                .WithMany()
                .IsRequired();
        }
    }
}