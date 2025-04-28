using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IManufacturerRepository
    {
        Task<Guid> Create(Manufacturer manufacturer);
        Task<Guid> Delete(Guid id);
        Task<List<Manufacturer>> Get();
        Task<Guid> Update(Guid id, string name, string contactInfo);
    }
}