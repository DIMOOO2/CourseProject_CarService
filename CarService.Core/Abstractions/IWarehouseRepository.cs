using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IWarehouseRepository
    {
        Task<Guid> Create(Warehouse warehouse);
        Task<Guid> Delete(Guid id);
        Task<List<Warehouse>> Get();
        Task<Guid> Update(Guid id, string title, string address, string city);
    }
}