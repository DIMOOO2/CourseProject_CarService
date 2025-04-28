using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class AutoPart
    {
        const int COUNT_SYMBOLS_PART_NUMBER = 6;
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

        public Guid AutoPartId { get; }
        public string AutoPartName { get; } = string.Empty;
        public long PartNumber { get; }
        public decimal Price { get; }
        public uint StockAmount { get; }
        public Guid ManufacturerId { get; }
        public Guid? WarehouseId { get; }

        public static (AutoPart AutoPart, string error) Create(Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Guid manufacturer, Guid? warehouse)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(autoPartName) || 
                partNumber.ToString().Length != COUNT_SYMBOLS_PART_NUMBER ||
                price <= 0 || stockAmount == 0
                || manufacturer == Guid.Empty)
            {
                error = "Error auto part is not created";
            }

            AutoPart autoPart = new AutoPart(autoPartId, autoPartName, partNumber, price, stockAmount, manufacturer!, warehouse);

            return (autoPart, error);
        }
    }
}
