using CarService.ApplicationService.Contracts.Requests;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;

namespace CarService.Administrator.Others.Models
{
    public partial class OrderModelAdmin : ObservableObject
    {
        /// <summary>
        /// Свойство содержащее информацию о заказе
        /// </summary>
        public OrderInfo OrderInfo { get; set; } 

        private HttpClient httpClient = new HttpClient(); //Новый HttpClient для отправки запроса о изменении статуса заказа

        /// <summary>
        /// Свойство для управлением возмодности выбора заказа в списке
        /// </summary>
        public bool IsEnabledItem => !OrderInfo.OrderStatus;

        /// <summary>
        /// Модель заказа в списке всех заказов у администратора
        /// </summary>
        public OrderModelAdmin()
        {
        }

        /// <summary>
        /// Выполнение заказа
        /// </summary>
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
