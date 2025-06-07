using CarService.Administrator.Others.Data;
using CarService.Administrator.Pages;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы складов
    /// </summary>
    public partial class WarehousesViewModel : ObservableObject
    {
        /// <summary>
        /// Список складов
        /// </summary>
        [ObservableProperty]
        ObservableCollection<Warehouse> warehouses;

        /// <summary>
        /// Выбранный склад
        /// </summary>
        [ObservableProperty]
        Warehouse selectedWarehouse;

        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        private HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Конструктор модели представления страницы складов
        /// </summary>
        public WarehousesViewModel()
        {
            try
            {
                UpdateCollection().GetAwaiter();
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Удаление склада из базы данных
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task RemoveItem()
        {
            try
            {
                if (SelectedWarehouse != null)
                {
                    if (await Application.Current!.MainPage!.DisplayAlert("", "Вы действительно хотите удалить данный склад", "OK", "Отмена"))
                    {
                        await httpClient.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Warehouse/{SelectedWarehouse.WarehouseId}");
                        Warehouses.Remove(SelectedWarehouse);
                    }
                    else return;
                }

                else return;
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Переход на страницу создания склада
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task CreateWarehouse()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(CreateWareousePage));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Переход на страницу обновления складов 
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task UpdateWarehouse()
        {
            try
            {
                AdminLocalData.SetWarehouse(SelectedWarehouse);
                await Shell.Current.GoToAsync(nameof(UpdateWarehousePage));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Обновление коллекции с помощью запроса на сервер
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task UpdateCollection()
        {
            Warehouses = new ObservableCollection<Warehouse>();
            WebData.GetCollectionWarehouses(await httpClient.GetFromJsonAsync<List<WarehouseResponse>>("https://localhost:1488/Warehouse"));
            WebData.GetCollectionAccounts(await httpClient.GetFromJsonAsync<List<CorporateAccountResponse>>("https://localhost:1488/CorporateAccount"));
            Warehouses = WebData.Warehouses!;
        }
    }
}
