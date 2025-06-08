using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий производителя
    /// </summary>
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly CarServiceDbContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public ManufacturerRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех производителей
        /// </summary>
        /// <returns></returns>
        public async Task<List<Manufacturer>> Get()
        {
            var manufacturerEntities = await _context.Manufacturers
                .AsNoTracking()
                .ToListAsync();

            var manufacturers = manufacturerEntities
                .Select(m => Manufacturer.Create(m.ManufacturerId, m.ManufacturerName, m.ContactInfo).Manufacturer)
                .ToList();

            return manufacturers;
        }

        /// <summary>
        /// Получение производителя по ID
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        public async Task<Manufacturer> GetById(Guid id)
        {
            var manufacturerEntity = await _context.Manufacturers.FirstOrDefaultAsync(m => m.ManufacturerId == id);

            if (manufacturerEntity != null)
            {
                var manufacturer = Manufacturer.Create(manufacturerEntity.ManufacturerId, manufacturerEntity.ManufacturerName,
                    manufacturerEntity.ContactInfo).Manufacturer;

                return manufacturer;
            }
            else return null!;
        }

        /// <summary>
        /// Создание производителя
        /// </summary>
        /// <param name="manufacturer">Новый производитель</param>
        /// <returns></returns>
        public async Task<Guid> Create(Manufacturer manufacturer)
        {
            ManufacturerEntity manufacturerEntity = new ManufacturerEntity()
            {
                ManufacturerId = manufacturer.ManufacturerId,
                ManufacturerName = manufacturer.ManufacturerName,
                ContactInfo = manufacturer.ContactInfo
            };

            await _context.Manufacturers.AddAsync(manufacturerEntity);
            await _context.SaveChangesAsync();

            return manufacturer.ManufacturerId;
        }

        /// <summary>
        /// Обновление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <param name="name">Название производителя</param>
        /// <param name="contactInfo">Контактная информация производителя (email)</param>
        /// <returns></returns>
        public async Task<Guid> Update(Guid id, string name, string contactInfo)
        {
            await _context.Manufacturers
                .Where(m => m.ManufacturerId == id)
                .ExecuteUpdateAsync(u => u
                .SetProperty(m => m.ManufacturerName, name)
                .SetProperty(m => m.ContactInfo, contactInfo));

            return id;
        }

        /// <summary>
        /// Удаление производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <returns></returns>
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Manufacturers
                .Where(m => m.ManufacturerId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
