using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий отчетов по поставкам
    /// </summary>
    public class DeliveryReportRepository : IDeliveryReportRepository
    {
        private readonly CarServiceDbContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public DeliveryReportRepository(CarServiceDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получение всех отчетов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение всех отчетов на конкретном складе
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение отчета по ID
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
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

        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="report">Новый отчет по поставке</param>
        /// <returns></returns>
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


        /// <summary>
        /// Обновление отчета
        /// </summary>
        /// <param name="reportId">ID отчета</param>
        /// <param name="createDate">Новая дата создания</param>
        /// <param name="warehouseCreatorId">ID склада-создателя</param>
        /// <param name="file">Файл-отчета</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление отчета
        /// </summary>
        /// <param name="id">ID отчета</param>
        /// <returns></returns>
        public async Task<Guid> Delete(Guid id)
        {
            await _context.DeliveryReports
                .Where(a => a.ReportId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
