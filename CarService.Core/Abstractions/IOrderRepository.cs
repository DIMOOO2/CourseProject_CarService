using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория заказов
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Создание заказов
        /// </summary>
        /// <param name="order">Новый заказ</param>
        /// <returns></returns>
        Task<Guid> Create(Order order);

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
        Task<Guid> Delete(Guid id);

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> Get();

        /// <summary>
        /// Получение заказа по ID
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
        Task<Order> GetById(Guid id);

        /// <summary>
        /// Получение всех заказов на конкретном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        Task<List<Order>> GetByWarehouseId(Guid warehouseId);

        /// <summary>
        /// Обновление заказа
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="orderDate">Дата оформления</param>
        /// <param name="orderStatus">Статус выполнения</param>
        /// <param name="clientId">ID клиента</param>
        /// <param name="warehouseContraсtorId">ID склада-исполнителя</param>
        /// <returns></returns>
        Task<Guid> Update(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContraсtorId);
    }
}