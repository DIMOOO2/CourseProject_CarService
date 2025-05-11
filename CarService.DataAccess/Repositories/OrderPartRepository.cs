using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class OrderPartRepository : IOrderPartRepository
    {
        private readonly CarServiceDbContext _context;

        public OrderPartRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderedPart>> Get()
        {
            var orderedPartEntities = await _context.OrderParts
                .AsNoTracking()
                .ToListAsync();

            var orderedParts = orderedPartEntities
                .Select(op => OrderedPart.Create(op.OrderedPartId, op.Amount, op.OrderId, op.AutoPartId,
                op.DepartureWarehouseId, op.ArrivalWarehouseId).OrderedPart)
                .ToList();

            return orderedParts;
        }

        public async Task<OrderedPart> GetById(Guid id)
        {
            var orderedpartEntity = await _context.OrderParts.FirstOrDefaultAsync(op => op.OrderedPartId == id);

            if (orderedpartEntity != null)
            {
                var orderedPart = OrderedPart.Create(orderedpartEntity.OrderedPartId, orderedpartEntity.Amount,
                    orderedpartEntity.OrderId, orderedpartEntity.AutoPartId,
                    orderedpartEntity.DepartureWarehouseId, orderedpartEntity.ArrivalWarehouseId).OrderedPart;

                return orderedPart;
            }
            else return null!;
        }

        public async Task<List<Guid>> Create(List<OrderedPart> orderedParts)
        {
            List<OrderPartEntity> orderedPartsInOrder = new List<OrderPartEntity>();

            foreach (var orderedPart in orderedParts)
            {
                OrderPartEntity orderPartEntity = new OrderPartEntity()
                {
                    OrderedPartId = orderedPart.OrderedPartId,
                    Amount = orderedPart.Amount,
                    OrderId = orderedPart.OrderId,
                    AutoPartId = orderedPart.AutoPartId,
                    DepartureWarehouseId = orderedPart.DepartureWarehouseId,
                    ArrivalWarehouseId = orderedPart.ArrivalWarehouseId
                };

                orderedPartsInOrder.Add(orderPartEntity);
            }

            await _context.OrderParts.AddRangeAsync(orderedPartsInOrder);
            await _context.SaveChangesAsync();

            return orderedPartsInOrder.Select(op => op.OrderedPartId).ToList();
        }

        public async Task<Guid> Update(Guid orderedPartId, uint amount,
            Guid orderId, Guid autoPartId,
            Guid departureWarehouseId, Guid? arrivalWarehouseId)
        {
            await _context.OrderParts
                .Where(op => op.OrderedPartId == orderedPartId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(op => op.Amount, amount)
                .SetProperty(op => op.OrderId, orderId)
                .SetProperty(op => op.AutoPartId, autoPartId)
                .SetProperty(op => op.DepartureWarehouseId, departureWarehouseId)
                .SetProperty(op => op.ArrivalWarehouseId, arrivalWarehouseId)
                );

            return orderedPartId;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.OrderParts
                .Where(op => op.OrderedPartId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
