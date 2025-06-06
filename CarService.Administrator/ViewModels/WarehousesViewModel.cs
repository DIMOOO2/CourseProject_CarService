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
    public partial class WarehousesViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Warehouse> warehouses;

        [ObservableProperty]
        Warehouse selectedWarehouse;

        private HttpClient httpClient = new HttpClient();

        public WarehousesViewModel()
        {
            try
            {
                UpdateCollection();
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async void RemoveItem()
        {
            try
            {
                if (SelectedWarehouse != null)
                {
                    if (await Application.Current!.MainPage!.DisplayAlert("", "Вы действительно хотите удалить данный склад", "OK", "Отмена"))
                    {
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

        [RelayCommand]
        private async void CreateWarehouse()
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

        [RelayCommand]
        private async void UpdateWarehouse()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(UpdateWarehousePage));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async void UpdateCollection()
        {
            Warehouses = new ObservableCollection<Warehouse>();
            WebData.GetCollectionWarehouses(await httpClient.GetFromJsonAsync<List<WarehouseResponse>>("https://localhost:1488/Warehouse"));
            Warehouses = WebData.Warehouses!;
        }
    }
}
