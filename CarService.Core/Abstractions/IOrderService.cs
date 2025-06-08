using CarService.Core.Models;

namespace CarService.Core.Abstractions
{ 
    /// <summary>
    /// Интерфейс сервиса для работы с заказами
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Создание заказов
        /// </summary>
        /// <param name="order">Новый заказ</param>
        /// <returns></returns>
        Task<Guid> CreateOrder(Order order);

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
        Task<Guid> DeleteOrder(Guid id);

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetAllOrders();

        /// <summary>
        /// Получение заказа по ID
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
        Task<Order> GetByIdOrder(Guid id);

        /// <summary>
        /// Получение всех заказов на конкретном складе
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        Task<List<Order>> GetOrdersFromCurrentWarehouse(Guid warehouseId);

        /// <summary>
        /// Обновление заказа
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="orderDate">Дата оформления</param>
        /// <param name="orderStatus">Статус выполнения</param>
        /// <param name="clientId">ID клиента</param>
        /// <param name="warehouseContractorId">ID склада-исполнителя</param>
        /// <returns></returns>
        Task<Guid> UpdateOrder(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContractorId);
    }
}