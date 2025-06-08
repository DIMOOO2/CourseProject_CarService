using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с запчастями в заказах
    /// </summary>
    public class OrderedPartService : IOrderedPartService
    {
        private readonly IOrderPartRepository _orderPartRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderPartRepository">Репозиторий запчастей в заказах</param>
        public OrderedPartService(IOrderPartRepository orderPartRepository)
        {
            _orderPartRepository = orderPartRepository;
        }

        /// <summary>
        /// Получение всех запчастей в заказах
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderedPart>> GetAllOrderedParts()
        {
            return await _orderPartRepository.Get();
        }

        /// <summary>
        /// Получение запчасти в заказе по ID
        /// </summary>
        /// <param name="id">ID запчасти в заказе</param>
        /// <returns></returns>
        public async Task<OrderedPart> GetByIdOrderedPart(Guid id)
        {
            return await _orderPartRepository.GetById(id);
        }

        /// <summary>
        /// Создание списка запчастей в заказе
        /// </summary>
        /// <param name="orderedParts">Новый список автозапчастей в заказе</param>
        /// <returns></returns>
        public async Task<List<Guid>> CreateOrderedParts(List<OrderedPart> orderedParts)
        {
            return await _orderPartRepository.Create(orderedParts);
        }

        /// <summary>
        /// Обновление запчасти в заказе
        /// </summary>
        /// <param name="orderedPartId">ID запчасти в заказе</param>
        /// <param name="amount">количество</param>
        /// <param name="orderId">ID заказа</param>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="departureWarehouseId">ID склада-отправителя</param>
        /// <returns></returns>
        public async Task<Guid> UpdateOrderedParts(Guid orderedPartId, uint amount, Guid orderId,
            Guid autoPartId, Guid departureWarehouseId)
        {
            return await _orderPartRepository.Update(orderedPartId, amount, orderId, autoPartId,
                departureWarehouseId);
        }

        /// <summary>
        /// Удаление автозапчасти в заказе
        /// </summary>
        /// <param name="id">ID запчасти в заказе</param>
        /// <returns></returns>
        public async Task<Guid> DeleteOrderedPart(Guid id)
        {
            return await _orderPartRepository.Delete(id);
        }
    }
}
