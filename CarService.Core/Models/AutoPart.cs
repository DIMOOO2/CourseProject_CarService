namespace CarService.Core.Models
{
    public class AutoPart
    {
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

        public AutoPart() { }

        public Guid AutoPartId { get; }
        public string AutoPartName { get; } = string.Empty;
        public long PartNumber { get; }
        public decimal Price { get; }
        public uint StockAmount { get; }
        public Guid ManufacturerId { get; }
        public Guid? WarehouseId { get; }

        public string GetPrice
        {
            get => $"{Price}₽";
        }
        public string GetStockAmount { get => $"{StockAmount} шт."; }

        public bool visibilityItem { get; set; } = true;

        public bool isEnabledItem { get; set; } = true;

        public string GetPartNumber => $"Артикул - {PartNumber}";

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
