using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace CarService.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий автозапчасти
    /// </summary>
    public class AutoPartRepository : IAutoPartRepository
    {
        private readonly CarServiceDbContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public AutoPartRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение списка автозапчастей
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение списка автозапчастей на определенном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение автозачасти по ID
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
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
        /// Метод создания автозачасти
        /// </summary>
        /// <param name="autoPart">Новая автозапчасть</param>
        /// <returns></returns>
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

        /// <summary>
        /// Обновление автозапчасти
        /// </summary>
        /// <param name="autoPartId">ID автозапчасти которую нужно обновить</param>
        /// <param name="autoPartName">название автозапчасти</param>
        /// <param name="partNumber">партийный номер</param>
        /// <param name="price">цена</param>
        /// <param name="stockAmount">количество</param>
        /// <param name="manufacturerId">ID производителя</param>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление автозапчасти по ID
        /// </summary>
        /// <param name="id">ID автозапчасти</param>
        /// <returns></returns>
        public async Task<Guid> Delete(Guid id)
        {
            await _context.AutoParts
                .Where(a => a.AutoPartId == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
