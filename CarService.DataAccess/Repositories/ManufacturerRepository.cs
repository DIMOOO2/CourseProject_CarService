using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly CarServiceDbContext _context;

        public ManufacturerRepository(CarServiceDbContext context)
        {
            _context = context;
        }

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

        public async Task<Guid> Update(Guid id, string name, string contactInfo)
        {
            await _context.Manufacturers
                .Where(m => m.ManufacturerId == id)
                .ExecuteUpdateAsync(u => u
                .SetProperty(m => m.ManufacturerName, name)
                .SetProperty(m => m.ContactInfo, contactInfo));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Manufacturers
                .Where(m => m.ManufacturerId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
