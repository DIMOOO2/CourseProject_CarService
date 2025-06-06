namespace CarService.Administrator
{
    /// <summary>
    /// Класс базовой инициализации приложения
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Конструктор базовой инициализации приложения
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}