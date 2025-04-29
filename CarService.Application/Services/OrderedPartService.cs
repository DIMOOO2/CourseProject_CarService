using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.Application.Services
{
    public class OrderedPartService : IOrderedPartService
    {
        private readonly IOrderPartRepository _orderPartRepository;

        public OrderedPartService(IOrderPartRepository orderPartRepository)
        {
            _orderPartRepository = orderPartRepository;
        }

        public async Task<List<OrderedPart>> GetAllOrderedParts()
        {
            return await _orderPartRepository.Get();
        }

        public async Task<Guid> CreateOrderedParts(OrderedPart orderedPart)
        {
            return await _orderPartRepository.Create(orderedPart);
        }

        public async Task<Guid> UpdateOrderedParts(Guid orderedPartId, uint amount, Guid orderId,
            Guid autoPartId, Guid departureWarehouseId, Guid? arrivalWarehouseId)
        {
            return await _orderPartRepository.Update(orderedPartId, amount, orderId, autoPartId,
                departureWarehouseId, arrivalWarehouseId);
        }

        public async Task<Guid> DeleteOrderedPart(Guid id)
        {
            return await _orderPartRepository.Delete(id);
        }
    }
}
