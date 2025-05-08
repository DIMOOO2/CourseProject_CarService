using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace CarService.DataAccess.Repositories
{
    public class AutoPartRepository : IAutoPartRepository
    {
        private readonly CarServiceDbContext _context;

        public AutoPartRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<AutoPart>> Get()
        {
            var autoPartEntities = await _context.AutoParts
                .AsNoTracking()
                .ToListAsync();

            var autoParts = autoPartEntities
                .Select(a => AutoPart.Create(a.AutoPartId, a.AutoPartName, a.PartNumber,
                a.Price, a.StockAmount, a.ManufacturerId, a.WarehouseId).AutoPart)
                .ToList();

            return autoParts;
        }

        public async Task<List<AutoPart>> GetByCurrentWarehouse(Guid warehouseId)
        {
            var autoPartEntities = await _context.AutoParts
                .Where(a => a.WarehouseId == warehouseId)
                .AsNoTracking()
                .ToListAsync();

            var autoParts = autoPartEntities
                .Select(a => AutoPart.Create(a.AutoPartId, a.AutoPartName, a.PartNumber,
                a.Price, a.StockAmount, a.ManufacturerId, a.WarehouseId).AutoPart).ToList();

            return autoParts!;
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

        public async Task<Guid> Create(AutoPart autoPart)
        {
            AutoPartEntity autoPartEntity = new AutoPartEntity()
            {
                AutoPartId = autoPart.AutoPartId,
                AutoPartName = autoPart.AutoPartName,
                PartNumber = autoPart.PartNumber,
                Price = autoPart.Price,
                StockAmount = autoPart.StockAmount,
                ManufacturerId = autoPart.ManufacturerId,
                WarehouseId = autoPart.WarehouseId
            };

            await _context.AutoParts.AddAsync(autoPartEntity);
            await _context.SaveChangesAsync();

            return autoPartEntity.AutoPartId;
        }

        public async Task<Guid> Update(Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId)
        {
            await _context.AutoParts
                .Where(a => a.AutoPartId == autoPartId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(a => a.AutoPartName, autoPartName)
                .SetProperty(a => a.PartNumber, partNumber)
                .SetProperty(a => a.Price, price)
                .SetProperty(a => a.StockAmount, stockAmount)
                .SetProperty(a => a.ManufacturerId, manufacturerId)
                .SetProperty(a => a.WarehouseId, warehouseId));

            return autoPartId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.AutoParts
                .Where(a => a.AutoPartId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
