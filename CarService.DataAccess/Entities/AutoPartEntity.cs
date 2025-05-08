using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Entities
{
    public class AutoPartEntity
    {
        public Guid AutoPartId { get; set; }
        public string AutoPartName { get; set; } = string.Empty;
        public long PartNumber { get; set; }
        [Precision(10, 2)]
        public decimal Price { get; set; }
        public uint StockAmount { get; set; }
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; } = null!;
        public Guid? WarehouseId { get; set; }
        public WarehouseEntity? Warehouse { get; set; } = null!;
    }
}
