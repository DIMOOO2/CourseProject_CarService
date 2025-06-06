using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarService.Administrator.ViewModels
{
    /// <summary>
    /// Класс модели представления страницы создания склада
    /// </summary>
    public partial class CreateWarehouseViewModel : ObservableObject
    {
        /// <summary>
        /// Название склада
        /// </summary>
        [ObservableProperty]
        private string title;

        /// <summary>
        /// Адрес склада
        /// </summary>
        [ObservableProperty]
        private string address;

        /// <summary>
        /// Город местонахождения склада
        /// </summary>
        [ObservableProperty]
        private string city;

        /// <summary>
        /// Логин для входа в учетную запись склада
        /// </summary>
        [ObservableProperty]
        private string login;

        /// <summary>
        /// Пароль для входа в учетную запись склада
        /// </summary>
        [ObservableProperty]
        private string password;

        /// <summary>
        /// Конструктор модели представления страницы создания складов
        /// </summary>
        public CreateWarehouseViewModel()
        {
        }

        /// <summary>
        /// Метод создания склада
        /// </summary>
        [RelayCommand]
        private void Create()
        {
            try
            {
                //Логика создания склада и аккаунта с помощью Post-Запросов
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }

        }
    }
}
