using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class DeliveryReportRepository : IDeliveryReportRepository
    {
        private readonly CarServiceDbContext _context;

        public DeliveryReportRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeliveryReport>> Get()
        {
            var reportEntities = await _context.DeliveryReports
                .AsNoTracking()
                .ToListAsync();

            var reports = reportEntities.
                Select(r => DeliveryReport.Create(r.ReportId, r.CreateDate, r.WarehouseCreatorId, r.ReportFile).report)
                .ToList();

            return reports;
        }

        public async Task<List<DeliveryReport>> GetByCurrentWarehouseId(Guid warehouseId)
        {
            var reportEntities = await _context.DeliveryReports
               .Where(dr => dr.WarehouseCreatorId == warehouseId)
               .AsNoTracking()
               .ToListAsync();

            var reports = reportEntities.
               Select(r => DeliveryReport.Create(r.ReportId, r.CreateDate,
               r.WarehouseCreatorId, r.ReportFile).report)
               .ToList();

            return reports;
        }

        public async Task<AutoPart> GetById(Guid id)
        {
            var autoPartEntity = await _context.AutoParts.FirstOrDefaultAsync(a => a.AutoPartId == id);

            if (autoPartEntity != null)
            {
                var autoPart = AutoPart.Create(autoPartEntity.AutoPartId, autoPartEntity.AutoPartName, autoPartEntity.PartNumber,
                autoPartEntity.Price, autoPartEntity.StockAmount, autoPartEntity.ManufacturerId, autoPartEntity.WarehouseId).AutoPart;

                return autoPart;
            }
            else return null!;
        }

        public async Task<Guid> Create(DeliveryReport report)
        {
            DeliveryReportEntity deliveryReport = new DeliveryReportEntity()
            {
                ReportId = report.ReportId,
                CreateDate = report.CreateDate,
                WarehouseCreatorId = report.WarehouseCreatorId,
                ReportFile = report.ReportFile
            };

            await _context.DeliveryReports.AddAsync(deliveryReport);
            await _context.SaveChangesAsync();

            return deliveryReport.ReportId;
        }

        public async Task<Guid> Update(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] file)
        {
            await _context.DeliveryReports
                .Where(dr => dr.ReportId == reportId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(dr => dr.CreateDate, createDate)
                .SetProperty(dr => dr.WarehouseCreatorId, warehouseCreatorId)
                .SetProperty(dr => dr.ReportFile, file));

            return reportId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.DeliveryReports
                .Where(a => a.ReportId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
