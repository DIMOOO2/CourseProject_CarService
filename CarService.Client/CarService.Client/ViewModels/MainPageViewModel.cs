using CarService.Client.Others.DataServises;
using CarService.Client.Pages;
using CarService.Models.Entities;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace CarService.Client.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private HttpClient client = new HttpClient();

    [ObservableProperty]
    bool isVisibleItems;

    [ObservableProperty]
    bool isVisibleUpdate;

    [ObservableProperty]
    ObservableCollection<Order>? ordersCollection;

    public MainPageViewModel()
    {
        UpdateRequest();
    }

    [RelayCommand]
    private void UpdateRequest()
    {
        //ObservableCollection<Order>? collectionOrders = WebData.Orders;
        //if (collectionOrders!.Count != 0)
        //{
        //    OrdersCollection = collectionOrders;
        //    IsVisibleItems = true;
        //    IsVisibleUpdate = false;
        //}
        //else
        //{
        //    IsVisibleItems = false;
        //    IsVisibleUpdate = true;
        //}
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