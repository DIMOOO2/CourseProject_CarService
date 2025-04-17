using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    public class CorporateAccount
    {
        [Key]
        public Guid AccountId { get; set; }
        public string LogIn { get; set; } = null!;
        public string Password { get; set; } = null!;
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
    }
}
