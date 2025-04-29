using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.Get();
        }

        public async Task<Guid> CreateOrder(Order order)
        {
            return await _orderRepository.Create(order);
        }

        public async Task<Guid> UpdateOrder(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId)
        {
            return await _orderRepository.Update(orderId, orderDate, orderStatus, clientId);
        }

        public async Task<Guid> DeleteOrder(Guid id)
        {
            return await _orderRepository.Delete(id);
        }
    }
}
