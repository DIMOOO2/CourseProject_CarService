using CarService.Administrator.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Administrator.ViewModels
{
    public partial class WarehousesViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Warehouse> warehouses;

        [ObservableProperty]
        Warehouse selectedWarehouse;

        public WarehousesViewModel()
        {
            try
            {
                Warehouses = new ObservableCollection<Warehouse>();
                Warehouses.Add(Warehouse.Create(Guid.NewGuid(), "test","test","test").Warehouse);
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
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
