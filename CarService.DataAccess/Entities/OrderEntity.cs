using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataAccess.Entities
{
    public class OrderEntity
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public Guid ClientId { get; set; }
        public ClientEntity? Client { get; set; } = null!;
        public List<OrderPartEntity> OrderParts { get; set; } = [];
    }
}
