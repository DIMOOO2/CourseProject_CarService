using CarService.Client.Others.LoginData;
using CarService.Client.Pages;

namespace CarService.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreateOrderPage), typeof(CreateOrderPage));
            Routing.RegisterRoute(nameof(AutoPartForClient), typeof(AutoPartForClient));
            FlyoutFooter = "Склад: " + LoginData.CurrentWarehouse?.Title;
        }
    }
}
