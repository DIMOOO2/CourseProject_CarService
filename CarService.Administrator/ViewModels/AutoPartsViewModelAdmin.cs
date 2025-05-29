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
    public partial class AutoPartsViewModelAdmin : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoParts;

        [ObservableProperty]
        private AutoPart selectedAutoPart;

        private HttpClient httpClient = new HttpClient();

        public AutoPartsViewModelAdmin()
        {
            try
            {
                AutoParts = new ObservableCollection<AutoPart>();
                UpdateCollection();       
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }

        }

        [RelayCommand]
        private void RemoveItem()
        {
            try
            {
                if (SelectedAutoPart != null)
                    AutoParts.Remove(SelectedAutoPart);

                else return;
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private async void UpdateItem()
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
                    await Toast.Make("Выберете элемент, который хотите удалить", ToastDuration.Short, 14).Show();
                    return;
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

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

        [RelayCommand]
        private async void UpdateCollection()
        {
            try
            {
                WebData.GetAutoPartsCollection(await httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart/fromWarehouse/{Guid.Empty}"));
                WebData.GetCollectionManufacturer(await httpClient.GetFromJsonAsync<List<ManufacturerResponse>>("https://localhost:1488/Manufacturer"));
                AutoParts = WebData.AutoParts!;
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}