using CarService.Client.Pages;

namespace CarService.Client
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

            Routing.RegisterRoute(nameof(CreateOrderPage), typeof(CreateOrderPage));
            Routing.RegisterRoute(nameof(AutoPartForClient), typeof(AutoPartForClient));
            Routing.RegisterRoute(nameof(NewArrivalPage), typeof(NewArrivalPage)); 
            Routing.RegisterRoute(nameof(ReportViewPage), typeof(ReportViewPage));
        }
    }
}
