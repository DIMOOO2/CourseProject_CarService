using CarService.Client.Others.DataServises;
using CarService.Core.Models;

namespace CarService.Client.Others.Models
{
    public class AutoPartInfo
    {
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

        public Guid AutoPartId { get; }
        public string AutoPartName { get; } = string.Empty;
        public long PartNumber { get; }
        public decimal Price { get; }
        public uint StockAmount { get; }
        public Guid ManufacturerId { get; }
        public Guid? WarehouseId { get; }


        public Manufacturer? Manufacturer 
        { 
            get 
            {
                return WebData.Manufacturers!.FirstOrDefault(m => m.ManufacturerId ==
                WebData.AllAutoParts!.FirstOrDefault(a => a.ManufacturerId == ManufacturerId)!.ManufacturerId)!;
            } 
        }


        public string GetAutoPartName => $"{AutoPartName}";
        public string GetPartNumber => $"Артикул: {PartNumber}";
        public string GetPrice
        {
            get => $"Цена: {Price}₽";
        }
        public string GetStockAmount { get => GetOpacity > 1 ? $"Количество: {StockAmount} шт." : string.Empty; }
        public string GetNameManufacturer { get => $"Производитель: {Manufacturer?.ManufacturerName}"; }

        public float GetOpacity
        {
            get
            {
                if(WarehouseId == LoginData.CurrentWarehouse!.WarehouseId)
                    return 1f;
                else return 0.5f;
            }
        }

        public string StockAvailability { get { return GetOpacity < 1 ? "Не в наличии" : "В наличии"; } }

    }
}
