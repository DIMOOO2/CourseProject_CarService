using CarService.Core.Abstractions;
using CarService.Core.Models;


namespace CarService.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<List<Warehouse>> GetAllWarehouse()
        {
            return await _warehouseRepository.Get();
        }

        public async Task<Warehouse> GetByIdWarehouse(Guid id)
        {
            return await _warehouseRepository.GetById(id);
        }
        public async Task<Guid> CreateWarehouse(Warehouse warehouse)
        {
            return await _warehouseRepository.Create(warehouse);
        }

        public async Task<Guid> UpdateWarehouse(Guid id, string title, string address, string city)
        {
            return await _warehouseRepository.Update(id, title, address, city);
        }

        public async Task<Guid> DeleteWarehouse(Guid id)
        {
            return await _warehouseRepository.Delete(id);
        }
    }
}