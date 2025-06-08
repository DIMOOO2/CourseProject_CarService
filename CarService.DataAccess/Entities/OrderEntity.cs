namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности заказа
    /// </summary>
    public class OrderEntity
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Дата оформления
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Статус выполнения
        /// </summary>
        public bool OrderStatus { get; set; }

        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Клиент
        /// </summary>
        public ClientEntity? Client { get; set; } = null!;

        /// <summary>
        /// ID склада-исполнителя
        /// </summary>
        public Guid WarehouseContractorId {  get; set; }

        /// <summary>
        /// Склад-исполнитель
        /// </summary>
        public WarehouseEntity? WarehouseContractor { get; set; }

        /// <summary>
        /// Список запчастей в заказе
        /// </summary>
        public List<OrderPartEntity> OrderParts { get; set; } = [];
    }
}
