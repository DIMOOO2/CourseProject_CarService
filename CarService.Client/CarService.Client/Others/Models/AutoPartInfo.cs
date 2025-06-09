using CarService.Client.Others.DataServises;
using CarService.Core.Models;

namespace CarService.Client.Others.Models
{
    /// <summary>
    /// Класс данных об автозапчасти
    /// </summary>
    public class AutoPartInfo
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="autoPartId">ID автозапчасти</param>
        /// <param name="autoPartName">Название автозапчасти</param>
        /// <param name="partNumber">Партийный номер</param>
        /// <param name="price">Цена</param>
        /// <param name="stockAmount">Количество\</param>
        /// <param name="manufacturerId">ID производителя</param>
        /// <param name="warehouseId">ID склада</param>
        public AutoPartInfo(Guid autoPartId, string autoPartName, long partNumber, decimal price, uint stockAmount, Guid manufacturerId, Guid? warehouseId)
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
        /// ID автозапчасти
        /// </summary>
        public Guid AutoPartId { get; }

        /// <summary>
        /// Название
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
        /// ID склада
        /// </summary>
        public Guid? WarehouseId { get; }


        /// <summary>
        /// Полная информация об производителе
        /// </summary>
        public Manufacturer? Manufacturer 
        { 
            get 
            {
                return WebData.Manufacturers!.FirstOrDefault(m => m.ManufacturerId ==
                WebData.AutoParts!.FirstOrDefault(a => a.ManufacturerId == ManufacturerId)!.ManufacturerId)!;
            } 
        }

        /// <summary>
        /// Свойство отображения автозапчасти
        /// </summary>
        public string GetAutoPartName => $"{AutoPartName}";

        /// <summary>
        /// Свойство отображения артикула
        /// </summary>
        public string GetPartNumber => $"Артикул: {PartNumber}";

        /// <summary>
        /// Свойство отображения цены
        /// </summary>
        public string GetPrice
        {
            get => $"Цена: {Price}₽";
        }

        /// <summary>
        /// Свойство отображения количества
        /// </summary>
        public string GetStockAmount { get => GetOpacity == 1 ? $"Количество: {StockAmount} шт." : string.Empty; }

        /// <summary>
        /// Свойство отображения названия производителя
        /// </summary>
        public string GetNameManufacturer { get => $"Производитель: {Manufacturer?.ManufacturerName}"; }

        /// <summary>
        /// Свойство отображения прозрачности в коллекции в зависимости от наличия на складе
        /// </summary>
        public float GetOpacity
        {
            get
            {
                if(StockAmount != 0)
                    return 1f;
                else return 0.5f;
            }
        }

        /// <summary>
        /// Свойство отображения статуса ниличия автозапчасти на складе
        /// </summary>
        public string StockAvailability { get { return GetOpacity < 1 ? "Не в наличии" : $"В наличии. {GetStockAmount}"; } }
    }
}
