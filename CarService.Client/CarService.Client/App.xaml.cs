using CarService.Client.Pages;

namespace CarService.Client
{
    /// <summary>
    /// Класс базовой инициализации приложения
    /// </summary>
    public partial class App : Microsoft.Maui.Controls.Application
    {
        /// <summary>
        /// Конструктор базовой инициализации приложения
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new AutorizationPage();
        }

        /// <summary>
        /// Метод создания первой страницы
        /// </summary>
        /// <param name="activationState">Интерфейс активации состояния</param>
        /// <returns></returns>
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            if (window != null)
            {
                window.Title = $"Автозапчасти.Логистика";
            }

            return window!;
        }
    }
}
