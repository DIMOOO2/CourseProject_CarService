using CarService.Client.Others.DataServises;

namespace CarService.Client.Others.Models
{
    /// <summary>
    /// Класс информации о заказе
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderId">ID заказа</param>
        /// <param name="orderDate">Дата оформления</param>
        /// <param name="orderStatus">Статус выполнения</param>
        public OrderInfo(Guid orderId, DateTime orderDate, bool orderStatus)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
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
        /// Клиент-заказчик
        /// </summary>
        public Core.Models.Client Client
        {
            get
            {
                return WebData.Clients!.FirstOrDefault(c => c.ClientId == WebData.Orders!.FirstOrDefault(o => o.OrderId == OrderId)!.ClientId)!;
            }
        }

        /// <summary>
        /// ID склада-исполнителя
        /// </summary>
        public Guid WarehouseContractorId { get; }

        /// <summary>
        /// Свойство рамки элемента заказа в коллекции 
        /// </summary>
        public Color ColorStatus
        {
            get
            {
                if (OrderStatus) return Color.FromArgb("#32cd32");
                else return Color.FromArgb("#ff1f1f");
            }
        }

        /// <summary>
        /// Артикул заказа
        /// </summary>
        public string ArticulNumber
        {
            get
            {
                byte[] data = OrderId.ToByteArray();
                return Math.Abs(BitConverter.ToInt32(data, 0)).ToString();
            }
        }

        /// <summary>
        /// Свойство отображения статуса выполнения заказа
        /// </summary>
        public string GetStatus
        {
            get
            {
                if (OrderStatus) return "Статус: Завершен";
                else return "Статус: Не завершен";
            }
        }

        /// <summary>
        /// Свойство отображения даты оформления 
        /// </summary>
        public string GetDate
        {
            get
            {
                return OrderDate.ToLongDateString().ToString();
            }
        }
    }
}
