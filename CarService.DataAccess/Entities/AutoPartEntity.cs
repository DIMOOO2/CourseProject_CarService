using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.Entities
{
    public class AutoPartEntity
    {
        public Guid AutoPartId { get; set; }
        public string AutoPartName { get; set; } = string.Empty;
        public long PartNumber { get; set; }
        public decimal Price { get; set; }
        public uint StockAmount { get; set; }
        public Guid ManufacturerId { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; } = null!;
        public Guid? WarehouseId { get; set; }
        public WarehouseEntity? Warehouse { get; set; } = null!;
    }
}
