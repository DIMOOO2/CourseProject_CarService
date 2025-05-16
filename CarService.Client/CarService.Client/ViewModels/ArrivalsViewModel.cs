using CarService.Client.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarService.Client.ViewModels
{
    public partial class ArrivalsViewModel : ObservableObject
    {
        public ArrivalsViewModel()
        {
        }

        [RelayCommand]
        public async void PushNewArrival()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(NewArrivalPage));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
