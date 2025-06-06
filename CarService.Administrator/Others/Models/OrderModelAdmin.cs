using CarService.ApplicationService.Contracts.Requests;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;

namespace CarService.Administrator.Others.Models
{
    public partial class OrderModelAdmin : ObservableObject
    {
        public OrderInfo OrderInfo { get; set; }

        private HttpClient httpClient = new HttpClient();
        public bool IsEnabledItem => !OrderInfo.OrderStatus;
        public OrderModelAdmin()
        {
        }

        [RelayCommand]
        private async void Execute()
        {
            try
            {
                using var response = await httpClient.PutAsJsonAsync<OrderRequest>($"https://localhost:1488/Order/{OrderInfo.OrderId}", new OrderRequest(OrderInfo.OrderDate, true, OrderInfo.Client.ClientId, OrderInfo.WarehouseContractorId));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Application.Current!.MainPage!.DisplayAlert("Сообщение", "Заказ успешно выполнен", "Ок");
                }
                else
                    throw new Exception("Ошибка при выполнении заказа");
            }
            catch
            {
                await Application.Current!.MainPage!.DisplayAlert("Сообщение", "Ошибка при выполнении заказа", "Ок");
            }
        }
    }
}
