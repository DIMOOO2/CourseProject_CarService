using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace CarService.Client.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private HttpClient client = new HttpClient();

    [ObservableProperty]
    bool isVisibleItems;

    [ObservableProperty]
    bool isVisibleUpdate;

    [ObservableProperty]
    ObservableCollection<OrderInfo>? ordersCollection;

    public MainPageViewModel()
    {
        try
        {
            UpdateRequest();
        }
        catch (Exception ex)
        {
            Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
        }
    }

    [RelayCommand]
    private void UpdateRequest()
    {
        try
        {
            ObservableCollection<Order>? collectionOrders = WebData.Orders;
            if (collectionOrders!.Count != 0)
            {
                ObservableCollection<OrderInfo> current = new ObservableCollection<OrderInfo>();

                foreach (var item in collectionOrders)
                {
                    current.Add(new OrderInfo(item.OrderId, item.OrderDate, item.OrderStatus));
                }

                OrdersCollection = current;
                IsVisibleItems = true;
                IsVisibleUpdate = false;
            }
            else
            {
                IsVisibleItems = false;
                IsVisibleUpdate = true;
            }
        }
        catch (Exception ex)
        {
            Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
        }
    }


    [RelayCommand]
    private async Task PushCreateOrderPage()
    {
        try
        {
            CartData.SetCart(null);
            await Shell.Current.GoToAsync(nameof(CreateOrderPage));
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
        }
    }
}