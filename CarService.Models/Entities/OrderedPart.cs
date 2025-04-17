using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    public class OrderedPart
    {
        [Key]
        public Guid OrderedPartId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        public AutoPart AutoPart { get; set; } 
        [ForeignKey("DepartureWarehouseId")]
        public Warehouse DepartureWarehouse { get; set; }
        [ForeignKey("ArrivalWarehouseId")]
        public Warehouse ArrivalWarehouse { get; set; }
    }
}
