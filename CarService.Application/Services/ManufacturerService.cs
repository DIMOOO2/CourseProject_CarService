using CarService.Core.Abstractions;
using CarService.Core.Models;


namespace CarService.Application.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            return await _manufacturerRepository.Get();
        }

        public async Task<Guid> CreateManufacturer(Manufacturer manufacturer)
        {
            return await _manufacturerRepository.Create(manufacturer);
        }

        public async Task<Guid> UpdateManufacturer(Guid id, string name, string contactInfo)
        {
            return await _manufacturerRepository.Update(id, name, contactInfo);
        }

        public async Task<Guid> DeleteManufacturer(Guid id)
        {
            return await _manufacturerRepository.Delete(id);
        }
    }
}
