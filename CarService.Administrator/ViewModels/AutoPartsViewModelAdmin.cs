using CarService.Administrator.Others.Data;
using CarService.Administrator.Pages;
using CarService.Core.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Administrator.ViewModels
{
    public partial class AutoPartsViewModelAdmin : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AutoPart> autoParts;

        [ObservableProperty]
        private AutoPart selectedAutoPart;

        public AutoPartsViewModelAdmin()
        {
            try
            {
                AutoParts = new ObservableCollection<AutoPart>();
                AutoParts.Add(AutoPart.Create(Guid.NewGuid(), "Test", 2, 18.00M, 7, Guid.NewGuid(), Guid.NewGuid()).AutoPart);
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
    }
}