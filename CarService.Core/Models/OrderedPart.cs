using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Core.Models
{
    public class OrderedPart
    {
        public OrderedPart(Guid orderedPartId, uint amount, Order order, AutoPart autoPart, 
            Warehouse departureWarehouse, Warehouse? arrivalWarehouse)
        {
            OrderedPartId = orderedPartId;
            Amount = amount;
            Order = order;
            AutoPart = autoPart;
            DepartureWarehouse = departureWarehouse;
            ArrivalWarehouse = arrivalWarehouse;
        }

        public Guid OrderedPartId { get; }
        public uint Amount { get; }
        public Order Order { get; } = null!;
        public AutoPart AutoPart { get; } = null!;
        public Warehouse DepartureWarehouse { get; } = null!;
        public Warehouse? ArrivalWarehouse { get; } = null!;

        public static (OrderedPart OrderedPart, string error) Create(Guid orderedPartId, uint amount,
            Order order, AutoPart autoPart,
            Warehouse departureWarehouse, Warehouse? arrivalWarehouse)
        {
            string error = string.Empty;

            if (amount == 0 ||
                order == null ||
                autoPart == null ||
                departureWarehouse == null)
            {
                error = "Error warehouse is not created";
            }

            OrderedPart orderedPart = new OrderedPart(orderedPartId, amount, order!, autoPart!, departureWarehouse!, arrivalWarehouse);

            return (orderedPart, error);
        }
    }
}
