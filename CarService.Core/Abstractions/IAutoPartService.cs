using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IAutoPartService
    {
        Task<Guid> CreateAutopart(AutoPart autoPart);
        Task<Guid> DeleteAutoPart(Guid id);
        Task<List<AutoPart>> GetAllAutoParts();
        Task<AutoPart> GetByIdAutoPart(Guid id);
        Task<Guid> UpdateAutoPart(Guid autoPartId, string autoPartName, long partNumber, decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId);
    }
}