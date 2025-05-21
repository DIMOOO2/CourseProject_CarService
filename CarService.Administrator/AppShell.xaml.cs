using CarService.Administrator.Pages;

namespace CarService.Administrator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateAutoPartPage), typeof(CreateAutoPartPage));
            Routing.RegisterRoute(nameof(UpdateAutoPartPage), typeof(UpdateAutoPartPage));
        }
    }
}
