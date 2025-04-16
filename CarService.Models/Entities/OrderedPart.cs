using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    public class OrderedPart
    {
        [Key]
        public Guid OrderedPartId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; } = null!;
        public AutoPart AutoPart { get; set; } = null!;
        [ForeignKey("DepartureWarehouseId")]
        public Warehouse DepartureWarehouse { get; set; } = null!;
        [ForeignKey("ArrivalWarehouseId")]
        public Warehouse ArrivalWarehouse { get; set; } = null!;
    }
}
