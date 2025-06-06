using CarService.Administrator.Others.Data;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы создания новой автозапчасти
    /// </summary>
    public partial class CreateAutoPartViewModel : ObservableObject
    {
        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        private HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Название автозапчасти
        /// </summary>
        [ObservableProperty]
        private string name;

        /// <summary>
        /// Цена автозачасти
        /// </summary>
        [ObservableProperty]
        private string price;

        /// <summary>
        /// Коллекция зарегистрированных складов
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Warehouse> warehouses;

        /// <summary>
        /// Выбранный склад
        /// </summary>
        [ObservableProperty]
        private Warehouse selectedWarehouse;

        /// <summary>
        /// Название производителя
        /// </summary>
        [ObservableProperty]
        private string manufacturerName;

        /// <summary>
        /// электронная почта производителя
        /// </summary>
        [ObservableProperty]
        private string manufacturerEmail;

        /// <summary>
        /// Конструктор модели представления страницы создания автозачасти
        /// </summary>
        public CreateAutoPartViewModel()
        {
            Warehouses = new ObservableCollection<Warehouse>();

            foreach (var item in WebData.Warehouses!)
            {
                Warehouses.Add(item);
            }
        }
        /// <summary>
        /// Поле хранящее данные по производителю
        /// </summary>
        private ManufacturerResponse? tempManufacturer;

        /// <summary>
        /// Метод создание новой автозапчасти
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task CreateAutoPart()
        {
            try
            {
                var manufacturerRequest = new ManufacturerRequest(ManufacturerName, ManufacturerEmail);
                using var response = await httpClient.PostAsJsonAsync<ManufacturerRequest>("https://localhost:1488/Manufacturer", manufacturerRequest);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    tempManufacturer = await response.Content.ReadFromJsonAsync<ManufacturerResponse>();


                    var autoPartRequest = new AutoPartRequest(Name, 0, Math.Round(Decimal.Parse(Price.Replace('.', ',')), 2), 0, tempManufacturer!.manufacturerId, SelectedWarehouse.WarehouseId);

                    using var responseAutoPart = await httpClient.PostAsJsonAsync<AutoPartRequest>("https://localhost:1488/AutoPart", autoPartRequest);

                    if (responseAutoPart.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        AutoPartResponse? autoPartResponse = await responseAutoPart.Content.ReadFromJsonAsync<AutoPartResponse>();
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Запчасть зарегистрирована, артикул {autoPartResponse!.partNumber}", "ОК");
                        await Shell.Current.Navigation.PopAsync();
                    }

                    else
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Запчасть зарегистрировать не удалось. Код ошибки {responseAutoPart.StatusCode}", "ОК");
                        await httpClient.DeleteFromJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{tempManufacturer!.manufacturerId}");
                    }
                }
                else
                    throw new Exception("Ошибка при создании склада");
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", ex.Message, "ОК");
                await httpClient.DeleteFromJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{tempManufacturer!.manufacturerId}");
            }  
        }
    }
}