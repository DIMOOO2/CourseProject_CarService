using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Models.Entities
{
    public class AutoPart
    {
        [Key]
        public Guid AutoPartId { get; set; }
        public string AutoPartName { get; set; } = null!;
        public int PartNumber { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; } = null!;
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; } = null!;

        [NotMapped]
        public string GetPrice
        {
            get => $"{Price}₽";
        }
         

        [NotMapped]
        public string GetStockAmount { get => $"{StockAmount} шт."; }
        [NotMapped]
        public string GetNameManufacturer { get => $"{Manufacturer.ManufacturerName}"; }
    }
}
