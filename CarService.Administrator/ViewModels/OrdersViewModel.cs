using CarService.Administrator.Others.Data;
using CarService.Administrator.Pages;
using CarService.Core.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Administrator.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Order> orders;

        [ObservableProperty]
        private Order selectedOrder;

        public OrdersViewModel()
        {
            try
            {
                Orders = new ObservableCollection<Order>();
                Orders.Add(Order.Create(Guid.NewGuid(), DateTime.MaxValue, false, Guid.NewGuid(), Guid.NewGuid()).Order);
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private void RemoveItem()
        {
            try
            {
                if (SelectedOrder != null)
                    Orders.Remove(SelectedOrder);

                else return;
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private void ExecuteOrder()
        {
            try
            {
                //Отправка запроса отправления обновленного заказа
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
