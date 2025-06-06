using CarService.Administrator.Others.Data;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы обновления автозачасти
    /// </summary>
    public partial class UpdateAutoPartViewModel : ObservableObject
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
        /// Количество экземпляров
        /// </summary>
        [ObservableProperty]
        private uint amount;

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
        /// Поле хранящее изначальную автозачасть 
        /// </summary>
        private AutoPartRequest tempAutoPart;

        /// <summary>
        /// Поле хранящее изначального производителя 
        /// </summary>
        private ManufacturerRequest tempManufacturer;

        // <summary>
        /// Конструктор модели представления страницы обновления автозачасти
        /// </summary>
        public UpdateAutoPartViewModel()
        {
            try
            {
                Name = AdminLocalData.CurrentAutoPart.AutoPartName;
                Price = AdminLocalData.CurrentAutoPart.Price.ToString();
                Amount = AdminLocalData.CurrentAutoPart.StockAmount;
                ManufacturerName = AdminLocalData.CurrentManufacturer!.ManufacturerName;
                ManufacturerEmail = AdminLocalData.CurrentManufacturer!.ContactInfo;

                tempAutoPart = new AutoPartRequest
                    (
                        Name, AdminLocalData.CurrentAutoPart.PartNumber, Math.Round(Decimal.Parse(Price.Replace('.', ',')), 2), Amount, AdminLocalData.CurrentManufacturer.ManufacturerId, AdminLocalData.CurrentAutoPart.WarehouseId
                    );

                tempManufacturer = new ManufacturerRequest(ManufacturerName, ManufacturerEmail);
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }

        }
        /// <summary>
        /// Метод обновления автозапчасти
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task Update()
        {
            try
            {
                using var responseManufacturer = await httpClient.PutAsJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{AdminLocalData.CurrentManufacturer.ManufacturerId}", 
                    new ManufacturerRequest(ManufacturerName, ManufacturerEmail));

                if (responseManufacturer.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using var responseAutoPart = await httpClient.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{AdminLocalData.CurrentAutoPart.AutoPartId}", new AutoPartRequest
                    (
                        Name, AdminLocalData.CurrentAutoPart.PartNumber, Math.Round(Decimal.Parse(Price.Replace('.', ',')), 2), Amount, AdminLocalData.CurrentManufacturer.ManufacturerId, Guid.Empty
                    ));
                    if (responseAutoPart.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Запчасть успешно обновлена", "ОК");
                        await Shell.Current.Navigation.PopAsync();
                    }
                }
                else
                    throw new Exception("Ошибка при обновлении склада");
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
                using var responseAutoPart = await httpClient.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{AdminLocalData.CurrentAutoPart.AutoPartId}", tempAutoPart);
                using var responseManufacturer = await httpClient.PutAsJsonAsync<ManufacturerRequest>($"https://localhost:1488/Manufacturer/{AdminLocalData.CurrentManufacturer.ManufacturerId}", tempManufacturer);
            }
        }
    }
}
