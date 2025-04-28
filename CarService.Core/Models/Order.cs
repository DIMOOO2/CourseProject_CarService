using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class Order
    {
        private Order(Guid orderId, DateTime orderDate, bool orderStatus, Client client)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            Client = client;
        }

        public Guid OrderId { get; }
        public DateTime OrderDate { get; }
        public bool OrderStatus { get; }
        public Client Client { get; } = null!;

        public static (Order Order, string error) Create(Guid orderId, DateTime orderDate, bool orderStatus, Client client)
        {
            string error = string.Empty;

            if (client == null)
            {
                error = "Error order is not created";
            }

            Order order = new Order(orderId, orderDate, orderStatus, client!);

            return (order, error);
        }
    }
}