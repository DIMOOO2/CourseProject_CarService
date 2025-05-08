using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IOrderedPartService
    {
        Task<Guid> CreateOrderedParts(OrderedPart orderedPart);
        Task<Guid> DeleteOrderedPart(Guid id);
        Task<List<OrderedPart>> GetAllOrderedParts();
        Task<OrderedPart> GetByIdOrderedPart(Guid id);
        Task<Guid> UpdateOrderedParts(Guid orderedPartId, uint amount, Guid orderId, Guid autoPartId, Guid departureWarehouseId, Guid? arrivalWarehouseId);
    }
}