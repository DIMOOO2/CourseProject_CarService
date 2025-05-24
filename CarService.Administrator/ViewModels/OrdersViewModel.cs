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
            Orders = new ObservableCollection<Order>();
            Orders.Add(Order.Create(Guid.NewGuid(), DateTime.MaxValue, false, Guid.NewGuid(), Guid.NewGuid()).Order);
        }

        [RelayCommand]
        private void RemoveItem()
        {
            if (SelectedOrder != null)
                Orders.Remove(SelectedOrder);

            else return;
        }

        [RelayCommand]
        private void ExecuteOrder()
        {
            //Отправка запроса отправления обновленного заказа
        }
    }
}
