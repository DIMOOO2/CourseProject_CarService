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
            Warehouses = new ObservableCollection<Warehouse>();
            Warehouses.Add(Warehouse.Create(Guid.NewGuid(), "test","test","test").Warehouse);
        }

        [RelayCommand]
        private async void RemoveItem()
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
    }
}
