namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности склада
    /// </summary>
    public class WarehouseEntity
    {
        /// <summary>
        /// ID склада
        /// </summary>
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Город местоположения
        /// </summary>
        public string City { get; set;  } = string.Empty;

        /// <summary>
        /// Список автозапчастей, которые есть на складе
        /// </summary>
        public List<AutoPartEntity> AutoParts { get; set; } = [];

        /// <summary>
        /// Список заказов, которые исполняют сотрудники склада
        /// </summary>
        public List<OrderEntity> Orders { get; set; }
    }
}
