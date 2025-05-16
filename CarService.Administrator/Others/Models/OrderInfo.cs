

namespace CarService.Administrator.Others.Models
{
    public class OrderInfo
    {
        public OrderInfo(Guid orderId, DateTime orderDate, bool orderStatus)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }

        public Guid OrderId { get; }
        public DateTime OrderDate { get; }
        public bool OrderStatus { get; }
        public Core.Models.Client Client
        {
            get
            {
                return Data.WebData.Clients!.FirstOrDefault(c => c.ClientId == Data.WebData.Orders!.FirstOrDefault(o => o.OrderId == OrderId)!.ClientId)!;
            }
        }

        public Guid WarehouseContractorId { get; }

        public Color ColorStatus
        {
            get
            {
                if (OrderStatus) return Color.FromArgb("#32cd32");
                else return Color.FromArgb("#ff1f1f");
            }
        }

        public string ArticulNumber
        {
            get
            {
                byte[] data = OrderId.ToByteArray();
                return Math.Abs(BitConverter.ToInt32(data, 0)).ToString();
            }
        }

        public string GetStatus
        {
            get
            {
                if (OrderStatus) return "Статус: Завершен";
                else return "Статус: Не завершен";
            }
        }

        public string GetDate
        {
            get
            {
                return OrderDate.ToLongDateString().ToString();
            }
        }
    }
}