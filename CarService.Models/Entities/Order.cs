using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models.Entities
{
    public class Order
    {
        int OrderId { get; set; }
        DateTime OrderDate { get; set; }
        Client Client { get; set; } = null!;
        string OrderStatus { get; set; } = null!;
    }
}
