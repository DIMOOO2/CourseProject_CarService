using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class AutoPart
    {
        [Key]
        public int AutoPartId { get; set; }
        public string AutoPartName { get; set; } = null!;
        public int PartNumber { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        public Manufacturer Manufacturer { get; set; } = null!;

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
