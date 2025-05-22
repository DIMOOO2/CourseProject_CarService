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
            Routing.RegisterRoute(nameof(NewArrivalPage), typeof(NewArrivalPage)); 
            Routing.RegisterRoute(nameof(ReportViewPage), typeof(ReportViewPage));
        }
    }
}
