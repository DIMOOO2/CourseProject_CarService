using CarService.Client.Pages;
using CarService.Client.ViewModels;
using Microsoft.Extensions.Logging;
using UraniumUI;



namespace CarService.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
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
            //builder.Services.AddSingleton<>(); Для ViewModel OrderPage

            builder.Services.AddSingleton<SearchAutoPart>();
            builder.Services.AddSingleton<SearchAutoPartViewModel>();

            builder.Services.AddTransient<CreateOrderPage>();
            builder.Services.AddTransient<CreateOrderViewModel>();

            return builder.Build();
        }
    }
}
