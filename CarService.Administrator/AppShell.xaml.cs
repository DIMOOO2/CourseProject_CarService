using CarService.Administrator.Pages;

namespace CarService.Administrator
{
    /// <summary>
    /// Класс оболочки приложения со всей навигацией по страницам
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Конструктор оболочки приложения со всей навигацией по страницам
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateAutoPartPage), typeof(CreateAutoPartPage));
            Routing.RegisterRoute(nameof(UpdateAutoPartPage), typeof(UpdateAutoPartPage));
            Routing.RegisterRoute(nameof(CreateWareousePage), typeof(CreateWareousePage));
            Routing.RegisterRoute(nameof(UpdateWarehousePage), typeof(UpdateWarehousePage));
        }
    }
}
