using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IManufacturerService
    {
        Task<Guid> CreateManufacturer(Manufacturer manufacturer);
        Task<Guid> DeleteManufacturer(Guid id);
        Task<List<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetByIdManufacturer(Guid id);
        Task<Guid> UpdateManufacturer(Guid id, string name, string contactInfo);
    }
}