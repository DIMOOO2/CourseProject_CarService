using CarService.Client.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarService.Client.ViewModels
{
    public partial class CreateOrderViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isNaturalPerson;
        
        [ObservableProperty]
        private bool isLegalEntity;

        public CreateOrderViewModel()
        {
            IsNaturalPerson = true;
            IsLegalEntity = false;
        }

        [RelayCommand]
        private async Task PushAutoPartForClient()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(AutoPartForClient));
            }
            catch (Exception ex)
            {
                await Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
