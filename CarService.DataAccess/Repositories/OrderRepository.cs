using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CarServiceDbContext _context;

        public OrderRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> Get()
        {
            var orderEntities = await _context.Orders
                .AsNoTracking()
                .ToListAsync();

            var orders = orderEntities
                .Select(o => Order.Create(o.OrderId, o.OrderDate, o.OrderStatus, o.ClientId).Order)
                .ToList();

            return orders;
        }

        public async Task<Order> GetById(Guid id)
        {
            var orderEntity = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            if (orderEntity != null)
            {
                var order = Order.Create(orderEntity.OrderId, orderEntity.OrderDate,
                orderEntity.OrderStatus, orderEntity.ClientId).Order;

                return order;
            }

            else return null!;
        }
       
        public async Task<Guid> Create(Order order)
        {
            OrderEntity orderEntity = new OrderEntity()
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus,
                ClientId = order.ClientId
            };

            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();

            return orderEntity.OrderId;
        }

        public async Task<Guid> Update(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId)
        {
            await _context.Orders
                .Where(o => o.OrderId == orderId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(o => o.OrderDate, orderDate)
                .SetProperty(o => o.OrderStatus, orderStatus)
                .SetProperty(o => o.ClientId, clientId));

            return orderId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Orders
                .Where(o => o.OrderId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}