namespace CarService.Core.Models
{
    /// <summary>
    /// Класс заказа
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="orderDate">Дата оформления</param>
        /// <param name="orderStatus">Статус выполнения</param>
        /// <param name="clientId">ID клиента</param>
        /// <param name="warehouseContractorId">ID склада-исполнителя</param>
        private Order(Guid orderId, DateTime orderDate, bool orderStatus, Guid clientId, Guid warehouseContractorId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            ClientId = clientId;
            WarehouseContractorId = warehouseContractorId;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// ID заказа
        /// </summary>
        public Guid OrderId { get; }

        /// <summary>
        /// Дата оформления
        /// </summary>
        public DateTime OrderDate { get; }

        /// <summary>
        /// Статус выполнения
        /// </summary>
        public bool OrderStatus { get; }

        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; }

        /// <summary>
        /// ID склада-исполнителя
        /// </summary>
        public Guid WarehouseContractorId { get; }

        /// <summary>
        /// Метод инициализации нового заказа
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="orderDate">Дата оформления</param>
        /// <param name="orderStatus">Статус выполнения</param>
        /// <param name="client">ID клиента</param>
        /// <param name="warehouseContractorId">ID склада-исполнителя</param>
        /// <returns></returns>
        public static (Order Order, string error) Create(Guid orderId, DateTime orderDate, bool orderStatus, Guid client, Guid warehouseContractorId)
        {
            string error = string.Empty;

            if (client == Guid.Empty || warehouseContractorId == Guid.Empty)
            {
                error = "Error order is not created";
            }

            Order order = new Order(orderId, orderDate, orderStatus, client!, warehouseContractorId);

            return (order, error);
        }
    }
}