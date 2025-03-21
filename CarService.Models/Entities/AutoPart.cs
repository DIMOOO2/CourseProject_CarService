using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class AutoPart
    {
        int AutoPartId { get; set; }
        string AutoPartName { get; set; } = null!;
        int PartNumber { get; set; }
        decimal Price { get; set; }
        int StockAmount { get; set; }
        Manufacturer manufacturer { get; set; }
    }
}
