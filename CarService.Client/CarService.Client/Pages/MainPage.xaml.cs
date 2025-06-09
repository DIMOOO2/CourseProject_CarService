using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// Класс страницы заказов
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
	/// Инициализация страницы
	/// </summary>
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}
