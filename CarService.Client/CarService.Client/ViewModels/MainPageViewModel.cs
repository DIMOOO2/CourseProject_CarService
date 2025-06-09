using CarService.ApplicationService.Contracts.Responses;
using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace CarService.Client.ViewModels;

/// <summary>
/// Класс модели представления главной страницы
/// </summary>
public partial class MainPageViewModel : ObservableObject
{
    /// <summary>
    /// Свойство видимости элементов списка заказов
    /// </summary>
    [ObservableProperty]
    bool isVisibleItems;

    /// <summary>
    /// Свойство видимости окна обновления списка
    /// </summary>
    [ObservableProperty]
    bool isVisibleUpdate;

    /// <summary>
    /// Список заказов
    /// </summary>
    [ObservableProperty]
    ObservableCollection<OrderInfo>? ordersCollection;

    /// <summary>
    /// Новый Http-клиент
    /// </summary>
    private HttpClient _httpClient = new HttpClient();

    /// <summary>
    /// Конструктор класса
    /// </summary>
    public MainPageViewModel()
    {
        try
        {
            UpdateRequest().GetAwaiter();
        }
        catch (Exception ex)
        {
            Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
        }
    }

    /// <summary>
    /// Обновление списка заказов
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task UpdateRequest()
    {
        try
        {
            WebData.GetOrdersCollection(await _httpClient.GetFromJsonAsync<List<OrderResponse>>($"https://localhost:1488/Order/fromWarehouse/{LoginData.CurrentWarehouse!.WarehouseId}"));
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
            await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
        }
    }

    /// <summary>
    /// Переход на страницу создания заказа
    /// </summary>
    /// <returns></returns>
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