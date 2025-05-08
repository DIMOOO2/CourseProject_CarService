using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;


namespace CarService.Client.Others.DataServises
{
    public static class WebData
    {
        public static ObservableCollection<AutoPart>? AutoParts { get; set; }
        public static ObservableCollection<Order>? Orders { get; set; }


        public static async void GetAutoPartsCollection(List<AutoPartResponse>? autoParts)
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

        public async static void GetOrdersCollection(ObservableCollection<Order>? orders)
        {
            Orders = orders;
            Debug.WriteLine(Orders?.Count);
        }
    }
}
