namespace CarService.Core.Models
{
    /// <summary>
    /// Класс запчасти в заказе
    /// </summary>
    public class OrderedPart
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="orderedPartId">ID запчасти в заказе</param>
        /// <param name="amount">Количество</param>
        /// <param name="orderId">ID заказа</param>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="departureWarehouseId">ID склада-отправителя</param>
        public OrderedPart(Guid orderedPartId, uint amount, Guid orderId, Guid autoPartId,
            Guid departureWarehouseId)
        {
            OrderedPartId = orderedPartId;
            Amount = amount;
            OrderId = orderId;
            AutoPartId = autoPartId;
            DepartureWarehouseId = departureWarehouseId;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public OrderedPart()
        {
        }

        /// <summary>
        /// ID запчасти в заказе
        /// </summary>
        public Guid OrderedPartId { get; }

        /// <summary>
        /// Количество
        /// </summary>
        public uint Amount { get; }

        /// <summary>
        /// ID заказа
        /// </summary>
        public Guid OrderId { get; }

        /// <summary>
        /// ID автозапчасти
        /// </summary>
        public Guid AutoPartId { get; }

        /// <summary>
        /// ID склада-отправителя
        /// </summary>
        public Guid DepartureWarehouseId { get; }


        /// <summary>
        /// Метод инициализации новой запчасти в заказе
        /// </summary>
        /// <param name="orderedPartId">ID запчасти в заказе</param>
        /// <param name="amount">Количество</param>
        /// <param name="order">ID заказа</param>
        /// <param name="autoPart">ID автозапчасти</param>
        /// <param name="departureWarehouse">ID склада-отправителя</param>
        /// <returns></returns>
        public static (OrderedPart OrderedPart, string error) Create(Guid orderedPartId, uint amount,
            Guid order, Guid autoPart,
            Guid departureWarehouse)
        {
            string error = string.Empty;

            if (amount == 0 ||
                order == Guid.Empty ||
                autoPart == Guid.Empty ||
                departureWarehouse == Guid.Empty)
            {
                error = "Error warehouse is not created";
            }

            OrderedPart orderedPart = new OrderedPart(orderedPartId, amount, order!, autoPart!, departureWarehouse!);

            return (orderedPart, error);
        }
    }
}
