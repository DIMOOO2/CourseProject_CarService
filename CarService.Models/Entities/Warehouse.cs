using System.ComponentModel.DataAnnotations;

namespace CarService.Models.Entities
{
    public class Warehouse
    {
        [Key]
        public long WarehouseId { get; set; }    
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}