using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace CarService.Client.Others.DataServises
{
    public static class WebData
    {
        public static ObservableCollection<AutoPart>? AutoParts { get; set; }
        public static ObservableCollection<Order>? Orders { get; set; }


        public static void GetAutoPartsCollection(List<AutoPartResponse>? autoParts)
        {
            ObservableCollection<AutoPart> currentAutoParts = new ObservableCollection<AutoPart>();
            foreach(var item in autoParts!)
            {
                currentAutoParts.Add(AutoPart.Create(item.autoPartId, item.autoPartName, item.partNumber,
                    item.price, item.stockAmount, item.manufacturerId, item.warehouseId).AutoPart);
            }

            AutoParts = currentAutoParts;
            Debug.WriteLine(AutoParts?.Count);
        }

        public static void GetOrdersCollection(List<OrderResponse>? orders)
        {
            ObservableCollection<Order> currentOrders = new ObservableCollection<Order>();
            foreach (var item in orders!)
            {
                currentOrders.Add(Order.Create(item.orderId, item.orderDate, item.orderStatus, 
                    item.clientId, item.warehouseContratorId).Order);
            }

            Orders = currentOrders;
            Debug.WriteLine(Orders?.Count);
        }
    }
}
