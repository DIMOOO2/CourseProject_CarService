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
    private async void UpdateRequest()
    {
        try
        {
            ObservableCollection<Order>? collectionOrders = await client.GetFromJsonAsync<ObservableCollection<Order>>("https://localhost:7196/orders");
            if (collectionOrders!.Count != 0)
            {
                OrdersCollection = collectionOrders;
                IsVisibleItems = true;
                IsVisibleUpdate = false;
            }
            else
            {
                IsVisibleItems = false;
                IsVisibleUpdate = true;
            }
        }
        catch (HttpRequestException)
        {
            await Application.Current!.MainPage!.DisplayAlert("Ошибка", "Не удалось подключиться к серверу, проверьте подключение к интернету или попробуйте позже", "ОК");
            IsVisibleItems = false;
            IsVisibleUpdate = true;
        }
    }
    

    [RelayCommand]
    private async Task PushCreateOrderPage()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(CreateOrderPage));
        }
        catch(Exception ex)
        {
           await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
        }
    }
}