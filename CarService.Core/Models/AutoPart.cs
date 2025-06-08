namespace CarService.Core.Models
{
    /// <summary>
    /// Класс автозапчасти
    /// </summary>
    public class AutoPart
    {
        /// <summary>
        /// Конструктор класса с параметрами
        /// </summary>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="autoPartName">Название автозапчасти</param>
        /// <param name="partNumber">Партийный номер</param>
        /// <param name="price">Цена</param>
        /// <param name="stockAmount">Количество</param>
        /// <param name="manufacturerId">ID производителя</param>
        /// <param name="warehouseId">ID склада местоположения</param>
        private AutoPart(Guid autoPartId, string autoPartName, long partNumber, 
            decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId)
        {
            AutoPartId = autoPartId;
            AutoPartName = autoPartName;
            PartNumber = partNumber;
            Price = price;
            StockAmount = stockAmount;
            ManufacturerId = manufacturerId;
            WarehouseId = warehouseId;
        }

        /// <summary>
        /// Конструктор класса без параметров
        /// </summary>
        public AutoPart() { }

        /// <summary>
        /// ID автозапчасти
        /// </summary>
        public Guid AutoPartId { get; }

        /// <summary>
        /// Название автозапчасти
        /// </summary>
        public string AutoPartName { get; } = string.Empty;

        /// <summary>
        /// Партийный номер
        /// </summary>
        public long PartNumber { get; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Количество
        /// </summary>
        public uint StockAmount { get; }

        /// <summary>
        /// ID производителя
        /// </summary>
        public Guid ManufacturerId { get; }

        /// <summary>
        /// ID склада местоположения
        /// </summary>
        public Guid? WarehouseId { get; }

        /// <summary>
        /// Цена в рублях
        /// </summary>
        public string GetPrice
        {
            get => $"{Price}₽";
        }

        /// <summary>
        /// Строка для отображения в рублях
        /// </summary>
        public string GetPriceWithInfo
        {
            get => $"Стоимость {Price}₽";
        }

        /// <summary>
        /// Количество в штуках
        /// </summary>
        public string GetStockAmount { get => $"{StockAmount} шт."; }

        /// <summary>
        /// Строка для отображения количество
        /// </summary>
        public string GetStockAmountWithInfo { get => $"Количество {StockAmount} шт."; }

        /// <summary>
        /// Строка для отображения названия автозапчасти
        /// </summary>
        public string GetNameWithInfo { get =>  $"Наименование - {AutoPartName}"; }


        /// <summary>
        /// Свойство видимости автозапчасти в списке приложений
        /// </summary>
        public bool VisibilityItem { get; set; } = true;

        /// <summary>
        /// Свойство возможности взаимодействия автозапчасти в списках у приложений
        /// </summary>
        public bool IsEnabledItem { get; set; } = true;

        /// <summary>
        /// Свойство отображения автозапчасти автозапчасти
        /// </summary>
        public string GetPartNumber => $"Артикул - {PartNumber}";

        /// <summary>
        /// Метод инициализации новой автозапчасти
        /// </summary>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="autoPartName">Название автозапчасти</param>
        /// <param name="partNumber">Партийный номер</param>
        /// <param name="price">Цена</param>
        /// <param name="stockAmount">Количество</param>
        /// <param name="manufacturer">ID производителя</param>
        /// <param name="warehouse">ID склада местоположения</param>
        /// <returns></returns>
        public static (AutoPart AutoPart, string error) Create(Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturer, Guid? warehouse)
        {
            string error = string.Empty;
            
            if (string.IsNullOrEmpty(autoPartName) 
                ||
                price <= 0
                || manufacturer == Guid.Empty)
            {
                error = "Error auto part is not created";
            }

            AutoPart autoPart = new AutoPart(autoPartId, autoPartName, partNumber, price, stockAmount, manufacturer!, warehouse);

            return (autoPart, error);
        }
    }
}
