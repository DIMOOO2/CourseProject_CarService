using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с заказами
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderRepository">Репозиторий заказа</param>
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.Get();
        }

        /// <summary>
        /// Получение заказа по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetByIdOrder(Guid id)
        {
            return await _orderRepository.GetById(id);
        }

        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="order">ID Заказа</param>
        /// <returns></returns>
        public async Task<Guid> CreateOrder(Order order)
        {
            return await _orderRepository.Create(order);
        }

        /// <summary>
        /// Обновление заказа
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="orderDate">Дата оформления</param>
        /// <param name="orderStatus">Статус выполнения</param>
        /// <param name="clientId">ID клиента</param>
        /// <param name="warehouseContratorId">ID склада-исполнителя</param>
        /// <returns></returns>
        public async Task<Guid> UpdateOrder(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContratorId)
        {
            return await _orderRepository.Update(orderId, orderDate, orderStatus, clientId, warehouseContratorId);
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
        public async Task<Guid> DeleteOrder(Guid id)
        {
            return await _orderRepository.Delete(id);
        }

        /// <summary>
        /// Получение заказов у конкретного склада-исполнителя
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <returns></returns>
        public async Task<List<Order>> GetOrdersFromCurrentWarehouse(Guid warehouseId)
        {
            return await _orderRepository.GetByWarehouseId(warehouseId);
        }
    }
}
