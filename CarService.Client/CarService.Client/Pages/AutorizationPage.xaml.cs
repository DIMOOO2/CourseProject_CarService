using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// Класс страницы авторизации
/// </summary>
public partial class AutorizationPage : ContentPage
{
    /// <summary>
    /// Инициализация страницы
    /// </summary>
    public AutorizationPage()
	{
		InitializeComponent();
		BindingContext = new AutorizationViewModel();
	}
}