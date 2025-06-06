using CarService.Administrator.Others.Data;
using CarService.Administrator.Others.Models;
using CarService.Administrator.Pages;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<OrderModelAdmin> orders;

        [ObservableProperty]
        private OrderModelAdmin selectedOrder;

        private HttpClient httpClient = new HttpClient();

        public OrdersViewModel()
        {
            try
            {                             
                UpdateCollection();
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async void RemoveItem()
        {
            try
            {
                if (SelectedOrder != null)
                    Orders.Remove(SelectedOrder);

                else 
                    await Toast.Make("Выберете элемент, который хотите удалить", ToastDuration.Short, 14).Show(); return;
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async void UpdateCollection()
        {
            Orders = new ObservableCollection<OrderModelAdmin>();
            WebData.GetClientCollection(await httpClient.GetFromJsonAsync<List<ClientResponse>>("https://localhost:1488/Client"));
            WebData.GetOrdersCollection(await httpClient.GetFromJsonAsync<List<OrderResponse>>("https://localhost:1488/Order"));

            foreach (var item in WebData.Orders!)
            {
                Orders.Add(new OrderModelAdmin() { OrderInfo = new OrderInfo(item.OrderId, item.OrderDate, item.OrderStatus, item.WarehouseContractorId) });
            }
        }
    }
}
