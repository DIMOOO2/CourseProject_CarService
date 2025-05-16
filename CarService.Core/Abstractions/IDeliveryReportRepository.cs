using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IDeliveryReportRepository
    {
        Task<Guid> Create(DeliveryReport report);
        Task<Guid> Delete(Guid id);
        Task<List<DeliveryReport>> Get();
        Task<List<DeliveryReport>> GetByCurrentWarehouseId(Guid warehouseId);
        Task<AutoPart> GetById(Guid id);
        Task<Guid> Update(Guid reportId, DateTime createDate, Guid warehouseCreatorId, byte[] file);
    }
}