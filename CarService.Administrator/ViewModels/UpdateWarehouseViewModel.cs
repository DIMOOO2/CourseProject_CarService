using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarService.Administrator.ViewModels
{
    public partial class UpdateWarehouseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;

        public UpdateWarehouseViewModel()
        {
        }

        [RelayCommand]
        private void Update()
        {
            try
            {
                //Логика обновление склада и аккаунта с помощью Post-Запросов
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
