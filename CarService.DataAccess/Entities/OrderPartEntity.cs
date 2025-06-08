namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности запчасти в заказе
    /// </summary>
    public class OrderPartEntity
    {
        /// <summary>
        /// ID запчасти в заказе
        /// </summary>
        public Guid OrderedPartId { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// ID заказа
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        public OrderEntity? Order { get; set; } = null!;

        /// <summary>
        /// ID автозапчасти
        /// </summary>
        public Guid AutoPartId { get; set; }

        /// <summary>
        /// Автозапчасть
        /// </summary>
        public AutoPartEntity? AutoPart { get; set; } = null!;

        /// <summary>
        /// ID склада-отправителя
        /// </summary>
        public Guid DepartureWarehouseId { get; set; }

        /// <summary>
        /// Склад-отправитель
        /// </summary>
        public WarehouseEntity? DepartureWarehouse { get; set; } = null!;
    }
}
