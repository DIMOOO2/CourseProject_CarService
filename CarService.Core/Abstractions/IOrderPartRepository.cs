using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IOrderPartRepository
    {
        Task<Guid> Create(OrderedPart orderedPart);
        Task<Guid> Delete(Guid id);
        Task<List<OrderedPart>> Get();
        Task<OrderedPart> GetById(Guid id);
        Task<Guid> Update(Guid orderedPartId, uint amount, Guid orderId,
            Guid autoPartId, Guid departureWarehouseId, Guid? arrivalWarehouseId);
    }
}