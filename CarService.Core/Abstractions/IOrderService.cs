using CarService.Core.Models;

namespace CarService.Core.Abstractions
{ 
    public interface IOrderService
    {
        Task<Guid> CreateOrder(Order order);
        Task<Guid> DeleteOrder(Guid id);
        Task<List<Order>> GetAllOrders();
        Task<Guid> UpdateOrder(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId);
    }
}