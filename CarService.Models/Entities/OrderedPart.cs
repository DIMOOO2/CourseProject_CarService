using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    public class OrderedPart
    {
        [Key]
        public long OrderedPartId { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; } = null!;
        public AutoPart AutoPart { get; set; } = null!;
        [ForeignKey("DepartureWarehouseId")]
        public Warehouse DepartureWarehouse { get; set; } = null!;
        [ForeignKey("ArrivalWarehouseId")]
        public Warehouse? ArrivalWarehouse { get; set; } = null!;

        [NotMapped]
        public bool IsCorrectData
        {
            get
            {
                if(Amount > 0
                   && Order != null
                   && AutoPart != null
                   && DepartureWarehouse != null
                   && ArrivalWarehouse != null) return true;
                else return false;
            }
        }
    }
}