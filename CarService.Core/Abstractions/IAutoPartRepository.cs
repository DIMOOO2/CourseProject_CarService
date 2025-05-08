using CarService.Core.Models;
using System.Collections.ObjectModel;

namespace CarService.Core.Abstractions
{
    public interface IAutoPartRepository
    {
        Task<Guid> Create(AutoPart autoPart);
        Task<Guid> Delete(Guid id);
        Task<List<AutoPart>> Get();
        Task<ObservableCollection<AutoPart>> GetByCurrentWarehouse(Guid warehouseId);
        Task<AutoPart> GetById(Guid id);
        Task<Guid> Update(Guid autoPartId, string autoPartName, long partNumber, decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId);
    }
}