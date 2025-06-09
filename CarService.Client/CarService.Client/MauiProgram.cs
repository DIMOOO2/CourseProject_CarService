using CarService.Client.Pages;
using CarService.Client.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace CarService.Client
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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            
            builder.Services.AddSingleton<AutorizationPage>();
            builder.Services.AddSingleton<AutorizationViewModel>(); 
            
            builder.Services.AddSingleton<OrderPage>();
            builder.Services.AddSingleton<ArrivalsViewModel>();

            builder.Services.AddSingleton<SearchAutoPart>();
            builder.Services.AddSingleton<SearchAutoPartViewModel>();

            builder.Services.AddTransient<CreateOrderPage>();
            builder.Services.AddTransient<CreateOrderViewModel>();

            builder.Services.AddTransient<ReportViewPage>();

            return builder.Build();
        }
    }
}
