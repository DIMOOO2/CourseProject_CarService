using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IDeliveryReportService
    {
        Task<Guid> CreateReport(DeliveryReport deliveryReport);
        Task<Guid> DeleteReport(Guid id);
        Task<List<DeliveryReport>> GetAllReports();
        Task<DeliveryReport> GetDeliveryReportById(Guid id);
        Task<List<DeliveryReport>> GetDeliveryReportsFromWarehouse(Guid warehouseId);
        Task<Guid> UpdateReport(Guid id, DateTime createDate, Guid warehouseCreatorId, byte[] file);
    }
}