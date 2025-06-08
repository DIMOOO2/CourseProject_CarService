using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с запчастями в заказе
    /// </summary>
    public interface IOrderedPartService
    {
        /// <summary>
        /// Создание запчастей в заказе
        /// </summary>
        /// <param name="orderedParts">Новая запчасть</param>
        /// <returns></returns>
        Task<List<Guid>> CreateOrderedParts(List<OrderedPart> orderedParts);

        /// <summary>
        /// Удаление запчасти в заказе
        /// </summary>
        /// <param name="id">ID запчасти</param>
        /// <returns></returns>
        Task<Guid> DeleteOrderedPart(Guid id);

        /// <summary>
        /// Получение всех запчастей в заказе
        /// </summary>
        /// <returns></returns>
        Task<List<OrderedPart>> GetAllOrderedParts();

        /// <summary>
        /// Получение запчасти в заказе по ID 
        /// </summary>
        /// <param name="id">ID запчасти</param>
        /// <returns></returns>
        Task<OrderedPart> GetByIdOrderedPart(Guid id);

        /// <summary>
        /// Обновление запчасти в заказе
        /// </summary>
        /// <param name="orderedPartId">ID запчасти в заказе</param>
        /// <param name="amount">Количество</param>
        /// <param name="orderId">ID заказа</param>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="departureWarehouseId">ID склада-отправителя</param>
        /// <returns></returns>
        Task<Guid> UpdateOrderedParts(Guid orderedPartId, uint amount, Guid orderId, Guid autoPartId, Guid departureWarehouseId);
    }
}