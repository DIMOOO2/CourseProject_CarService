using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
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

        public async Task<Order> GetByIdOrder(Guid id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<Guid> CreateOrder(Order order)
        {
            return await _orderRepository.Create(order);
        }

        public async Task<Guid> UpdateOrder(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContratorId)
        {
            return await _orderRepository.Update(orderId, orderDate, orderStatus, clientId, warehouseContratorId);
        }

        public async Task<Guid> DeleteOrder(Guid id)
        {
            return await _orderRepository.Delete(id);
        }

        public async Task<List<Order>> GetOrdersFromCurrentWarehouse(Guid warehouseId)
        {
            return await _orderRepository.GetByWarehouseId(warehouseId);
        }
    }
}
