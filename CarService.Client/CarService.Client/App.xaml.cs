using CarService.Client.Pages;

namespace CarService.Client
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AutorizationPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            if (window != null)
            {
                window.Title = $"Автозапчасти.Логистика";
            }

            return window;
        }
    }
}
