using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IOrderRepository
    {
        Task<Guid> Create(Order order);
        Task<Guid> Delete(Guid id);
        Task<List<Order>> Get();
        Task<Order> GetById(Guid id);
        Task<Guid> Update(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId);
    }
}