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
        public OrderedPart(Guid orderedPartId, uint amount, Guid orderId, Guid autoPartId,
            Guid departureWarehouseId, Guid? arrivalWarehouseId)
        {
            OrderedPartId = orderedPartId;
            Amount = amount;
            OrderId = orderId;
            AutoPartId = autoPartId;
            DepartureWarehouseId = departureWarehouseId;
            ArrivalWarehouseId = arrivalWarehouseId;
        }

        public OrderedPart()
        {
        }

        public Guid OrderedPartId { get; }
        public uint Amount { get; }
        public Guid OrderId { get; }
        public Guid AutoPartId { get; }
        public Guid DepartureWarehouseId { get; }
        public Guid? ArrivalWarehouseId { get; }

        public static (OrderedPart OrderedPart, string error) Create(Guid orderedPartId, uint amount,
            Guid order, Guid autoPart,
            Guid departureWarehouse, Guid? arrivalWarehouse)
        {
            string error = string.Empty;

            if (amount == 0 ||
                order == Guid.Empty ||
                autoPart == Guid.Empty ||
                departureWarehouse == Guid.Empty)
            {
                error = "Error warehouse is not created";
            }

            OrderedPart orderedPart = new OrderedPart(orderedPartId, amount, order!, autoPart!, departureWarehouse!, arrivalWarehouse);

            return (orderedPart, error);
        }
    }
}
