using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.Entities
{
    public class OrderPartEntity
    {
        public Guid OrderedPartId { get; set; }
        public uint Amount { get; set; }
        public Guid OrderId { get; set; }
        public OrderEntity? Order { get; set; } = null!;
        public Guid AutoPartId { get; set; }
        public AutoPartEntity? AutoPart { get; set; } = null!;
        public Guid DepartureWarehouseId { get; set; }
        public WarehouseEntity? DepartureWarehouse { get; set; } = null!;
    }
}
