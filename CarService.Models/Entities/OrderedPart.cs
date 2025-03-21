using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class OrderedPart
    {
        int OrderedPartId { get; set; }
        Order order { get; set; } = null!;
        AutoPart autoPart { get; set; } = null!;
        int Amount { get; set; }
    }
}
