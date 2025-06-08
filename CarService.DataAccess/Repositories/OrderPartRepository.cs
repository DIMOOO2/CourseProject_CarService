using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий запчасти в заказе
    /// </summary>
    public class OrderPartRepository : IOrderPartRepository
    {
        private readonly CarServiceDbContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public OrderPartRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех запчастей в заказе
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderedPart>> Get()
        {
            var orderedPartEntities = await _context.OrderParts
                .AsNoTracking()
                .ToListAsync();

            var orderedParts = orderedPartEntities
                .Select(op => OrderedPart.Create(op.OrderedPartId, op.Amount, op.OrderId, op.AutoPartId,
                op.DepartureWarehouseId).OrderedPart)
                .ToList();

            return orderedParts;
        }

        /// <summary>
        /// Получение запчасти в заказе по ID 
        /// </summary>
        /// <param name="id">ID запчасти</param>
        /// <returns></returns>
        public async Task<OrderedPart> GetById(Guid id)
        {
            var orderedpartEntity = await _context.OrderParts.FirstOrDefaultAsync(op => op.OrderedPartId == id);

            if (orderedpartEntity != null)
            {
                var orderedPart = OrderedPart.Create(orderedpartEntity.OrderedPartId, orderedpartEntity.Amount,
                    orderedpartEntity.OrderId, orderedpartEntity.AutoPartId,
                    orderedpartEntity.DepartureWarehouseId).OrderedPart;

                return orderedPart;
            }
            else return null!;
        }

        /// <summary>
        /// Создание запчастей в заказе
        /// </summary>
        /// <param name="orderedParts">Новая запчасть</param>
        /// <returns></returns>
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
                    DepartureWarehouseId = orderedPart.DepartureWarehouseId
                };

                orderedPartsInOrder.Add(orderPartEntity);
            }

            await _context.OrderParts.AddRangeAsync(orderedPartsInOrder);
            await _context.SaveChangesAsync();

            return orderedPartsInOrder.Select(op => op.OrderedPartId).ToList();
        }

        /// <summary>
        /// Обновление запчасти в заказе
        /// </summary>
        /// <param name="orderedPartId">ID запчасти в заказе</param>
        /// <param name="amount">Количество</param>
        /// <param name="orderId">ID заказа</param>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="departureWarehouseId">ID склада-отправителя</param>
        /// <returns></returns>
        public async Task<Guid> Update(Guid orderedPartId, uint amount,
            Guid orderId, Guid autoPartId,
            Guid departureWarehouseId)
        {
            await _context.OrderParts
                .Where(op => op.OrderedPartId == orderedPartId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(op => op.Amount, amount)
                .SetProperty(op => op.OrderId, orderId)
                .SetProperty(op => op.AutoPartId, autoPartId)
                .SetProperty(op => op.DepartureWarehouseId, departureWarehouseId)
                );

            return orderedPartId;
        }

        /// <summary>
        /// Удаление запчасти в заказе
        /// </summary>
        /// <param name="id">ID запчасти</param>
        /// <returns></returns>
        public async Task<Guid> Delete(Guid id)
        {
            await _context.OrderParts
                .Where(op => op.OrderedPartId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
