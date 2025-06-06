using Microsoft.Extensions.Logging;
using UraniumUI;
using CommunityToolkit.Maui;

namespace CarService.Administrator
{
    /// <summary>
    /// Класс инициализации ресурсов в приложении
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Метод создания приложения
        /// </summary>
        /// <returns></returns>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
