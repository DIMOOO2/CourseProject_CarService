namespace CarService.Administrator.Others.Models
{
    /// <summary>
    /// Класс, содержащий информацию о заказе
    /// </summary>
    public partial class OrderInfo
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderId">Уникальный идентификатор заказа</param>
        /// <param name="orderDate">Дата оформления заказа</param>
        /// <param name="orderStatus">Статус выполнения заказа</param>
        /// <param name="warehouseContractorId">Идентификатор склада-исполнителя</param>
        public OrderInfo(Guid orderId, DateTime orderDate, bool orderStatus, Guid warehouseContractorId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            WarehouseContractorId = warehouseContractorId;
        }
        /// <summary>
        /// Свойство уникального идентификатор заказа
        /// </summary>
        public Guid OrderId { get; }
        /// <summary>
        /// Свойство даты оформления заказа
        /// </summary>
        public DateTime OrderDate { get; }
        /// <summary>
        /// Свойство статуса выполнения заказа
        /// </summary>
        public bool OrderStatus { get; }
        /// <summary>
        /// Свойство поиска клиента по его идентификатору
        /// </summary>
        public Core.Models.Client Client
        {
            get
            {
                return Data.WebData.Clients!.FirstOrDefault(c => c.ClientId == Data.WebData.Orders!.FirstOrDefault(o => o.OrderId == OrderId)!.ClientId)!;
            }
        }
        /// <summary>
        /// Свойство уникального идентификатора склада-исполнителя
        /// </summary>
        public Guid WarehouseContractorId { get; }

        /// <summary>
        /// Свойство, отвечающее за цвет рамки заказа. При выполненном статусе ставится зеленый цвет, в противном случае - красный
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
        /// Свойство получения артикула заказа в виде информационной строки
        /// </summary>
        public string ArticulNumber
        {
            get
            {
                byte[] data = OrderId.ToByteArray();
                return "Номер заказа: " + Math.Abs(BitConverter.ToInt32(data, 0)).ToString();
            }
        }
        /// <summary>
        /// Свойство вывода статуса ввиде информационной строки
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
        /// Свойство вывода даты оформления ввиде информационной строки
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