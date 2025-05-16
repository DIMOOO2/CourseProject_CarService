using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    public class DeliveryReportService : IDeliveryReportService
    {
        private readonly IDeliveryReportRepository _repository;

        public DeliveryReportService(IDeliveryReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DeliveryReport>> GetAllReports()
        {
            return await _repository.Get();
        }

        public async Task<List<DeliveryReport>> GetDeliveryReportsFromWarehouse(Guid warehouseId)
        {
            return await _repository.GetByCurrentWarehouseId(warehouseId);
        }

        public async Task<DeliveryReport> GetDeliveryReportById(Guid id)
        {
            return await GetDeliveryReportById(id);
        }

        public Task<Guid> CreateReport(DeliveryReport deliveryReport)
        {
            return _repository.Create(deliveryReport);
        }

        public async Task<Guid> UpdateReport(Guid id, DateTime createDate, Guid warehouseCreatorId, byte[] file)
        {
            return await _repository.Update(id, createDate, warehouseCreatorId, file);
        }

        public async Task<Guid> DeleteReport(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
