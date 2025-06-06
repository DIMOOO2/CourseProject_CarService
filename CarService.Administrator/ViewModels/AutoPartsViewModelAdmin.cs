using CarService.Administrator.Others.Data;
using CarService.Administrator.Pages;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Модель представления страницы автозапчастей в приложении админитсратора
    /// </summary>
    public partial class AutoPartsViewModelAdmin : ObservableObject
    {
        /// <summary>
        /// Коллекция автозачастей
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoParts;

        /// <summary>
        /// Выбранная автозачасть
        /// </summary>
        [ObservableProperty]
        private AutoPart selectedAutoPart;

        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        private HttpClient httpClient = new HttpClient();
        /// <summary>
        /// Конструктор для инициализации модели представления
        /// </summary>
        public AutoPartsViewModelAdmin()
        {
            try
            {
                AutoParts = new ObservableCollection<AutoPart>();
                UpdateCollection().GetAwaiter();       
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }

        }
        /// <summary>
        /// Удаляет автозачасть из списка
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task RemoveItem()
        {
            try
            {
                if (SelectedAutoPart != null)
                {
                    if(await Application.Current!.MainPage!.DisplayAlert("", "Вы действительно хотите удалить данную запчасть", "OK", "Отмена"))
                    {
                        await httpClient.DeleteFromJsonAsync<Guid>($"https://localhost:1488/Order/{SelectedAutoPart.AutoPartId}");
                        AutoParts.Remove(SelectedAutoPart);
                    }
                }
                    
                else
                {
                    await Toast.Make("Выберете элемент, который хотите удалить", ToastDuration.Short, 14).Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
        /// <summary>
        /// Переходит на страницу обновления данных по автозачасти
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task UpdateItem()
        {
            try
            {
                if (SelectedAutoPart != null)
                {
                    AdminLocalData.SetAutoPart(SelectedAutoPart);
                    
                    await Shell.Current.GoToAsync(nameof(UpdateAutoPartPage));
                }
                else
                {
                    await Toast.Make("Выберете элемент, который хотите обновить", ToastDuration.Short, 14).Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Переходит на страницу создания новой автозачасти
        /// </summary>
        [RelayCommand]
        private void CreateItem()
        {
            try
            {
                Shell.Current.GoToAsync(nameof(CreateAutoPartPage));
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
        /// <summary>
        /// Метод обновления коллекции автозачастей, согласно данным сервера
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task UpdateCollection()
        {
            try
            {
                WebData.GetAutoPartsCollection(await httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart/fromWarehouse/{Guid.Empty}"));
                WebData.GetCollectionManufacturer(await httpClient.GetFromJsonAsync<List<ManufacturerResponse>>("https://localhost:1488/Manufacturer"));
                WebData.GetCollectionWarehouses(await httpClient.GetFromJsonAsync<List<WarehouseResponse>>("https://localhost:1488/Warehouse"));
                AutoParts = WebData.AutoParts!;
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}