using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly CarServiceDbContext _context;

        public WarehouseRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Warehouse>> Get()
        {
            var warehouseEntities = await _context.Warehouses
                .AsNoTracking()
                .ToListAsync();

            var warehouses = warehouseEntities
                .Select(w => Warehouse.Create(w.WarehouseId, w.Title, w.Address, w.City).Warehouse)
                .ToList();

            return warehouses;
        }

        public async Task<Warehouse> GetById(Guid id)
        {
            var warehouseEntities = await _context.Warehouses.FirstOrDefaultAsync(w => w.WarehouseId == id);

            if (warehouseEntities != null)
            {
                var warehouse = Warehouse.Create(warehouseEntities.WarehouseId, warehouseEntities.Title,
                    warehouseEntities.Address, warehouseEntities.City).Warehouse;

                return warehouse;
            }

            else return null!;
        }

        public async Task<Guid> Create(Warehouse warehouse)
        {
            WarehouseEntity warehouseEntity = new WarehouseEntity
            {
                WarehouseId = warehouse.WarehouseId,
                Title = warehouse.Title,
                Address = warehouse.Address,
                City = warehouse.City
            };

            await _context.Warehouses.AddAsync(warehouseEntity);
            await _context.SaveChangesAsync();

            return warehouseEntity.WarehouseId;
        }

        public async Task<Guid> Update(Guid id, string title, string address, string city)
        {
            await _context.Warehouses
                .Where(w => w.WarehouseId == id)
                .ExecuteUpdateAsync(u => u
                .SetProperty(w => w.Title, w => title)
                .SetProperty(w => w.Address, w => address)
                .SetProperty(w => w.City, w => city));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Warehouses
                .Where(w => w.WarehouseId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}