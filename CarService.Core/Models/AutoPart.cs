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
            decimal price, uint stockAmount, Manufacturer manufacturer, Warehouse? warehouse)
        {
            AutoPartId = autoPartId;
            AutoPartName = autoPartName;
            PartNumber = partNumber;
            Price = price;
            StockAmount = stockAmount;
            Manufacturer = manufacturer;
            Warehouse = warehouse;
        }

        public Guid AutoPartId { get; }
        public string AutoPartName { get; } = string.Empty;
        public long PartNumber { get; }
        public decimal Price { get; }
        public uint StockAmount { get; }
        public Manufacturer Manufacturer { get; } = null!;
        public Warehouse? Warehouse { get; } = null!;

        public static (AutoPart AutoPart, string error) Create(Guid autoPartId, string autoPartName, long partNumber,
            decimal price, uint stockAmount, Manufacturer manufacturer, Warehouse? warehouse)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(autoPartName) || 
                partNumber.ToString().Length != COUNT_SYMBOLS_PART_NUMBER ||
                price <= 0 ||
                manufacturer == null ||
                stockAmount == 0)
            {
                error = "Error auto part is not created";
            }

            AutoPart autoPart = new AutoPart(autoPartId, autoPartName, partNumber, price, stockAmount, manufacturer!, warehouse);

            return (autoPart, error);
        }
    }
}
