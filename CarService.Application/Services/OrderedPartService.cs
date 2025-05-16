using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
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

        public async Task<OrderedPart> GetByIdOrderedPart(Guid id)
        {
            return await _orderPartRepository.GetById(id);
        }

        public async Task<List<Guid>> CreateOrderedParts(List<OrderedPart> orderedParts)
        {
            return await _orderPartRepository.Create(orderedParts);
        }

        public async Task<Guid> UpdateOrderedParts(Guid orderedPartId, uint amount, Guid orderId,
            Guid autoPartId, Guid departureWarehouseId)
        {
            return await _orderPartRepository.Update(orderedPartId, amount, orderId, autoPartId,
                departureWarehouseId);
        }

        public async Task<Guid> DeleteOrderedPart(Guid id)
        {
            return await _orderPartRepository.Delete(id);
        }
    }
}
