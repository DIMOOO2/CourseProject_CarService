using CarService.Core.Abstractions;
using CarService.Core.Models;


namespace CarService.ApplicationService.Services
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
        public async Task<Manufacturer> GetByIdManufacturer(Guid id)
        {
            return await _manufacturerRepository.GetById(id);
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
