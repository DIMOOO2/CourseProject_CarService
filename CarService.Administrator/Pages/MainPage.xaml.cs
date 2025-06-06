using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages
{
    /// <summary>
    /// Класс страницы автозачастей
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Конструктор страницы автозачастей
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AutoPartsViewModelAdmin();
        }
    }
}
