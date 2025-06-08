using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности автозапчасти
    /// </summary>
    public class AutoPartEntity
    {
        /// <summary>
        /// ID автозапчасти
        /// </summary>
        public Guid AutoPartId { get; set; }

        /// <summary>
        /// Название автозапчасти
        /// </summary>
        public string AutoPartName { get; set; } = string.Empty;

        /// <summary>
        /// Партийный номер
        /// </summary>
        public long PartNumber { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [Precision(10, 2)]
        public decimal Price { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public uint StockAmount { get; set; }

        /// <summary>
        /// ID производителя
        /// </summary>
        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        public ManufacturerEntity? Manufacturer { get; set; } = null!;

        /// <summary>
        /// ID склада расположения
        /// </summary>
        public Guid? WarehouseId { get; set; }

        /// <summary>
        /// Склад расположения
        /// </summary>
        public WarehouseEntity? Warehouse { get; set; } = null!;
    }
}
