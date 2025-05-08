using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IWarehouseService
    {
        Task<Guid> CreateWarehouse(Warehouse warehouse);
        Task<Guid> DeleteWarehouse(Guid id);
        Task<List<Warehouse>> GetAllWarehouse();
        Task<Warehouse> GetByIdWarehouse(Guid id);
        Task<Guid> UpdateWarehouse(Guid id, string title, string address, string city);
    }
}