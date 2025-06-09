using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// Класс страницы запчастей для клиентов
/// </summary>
public partial class AutoPartForClient : ContentPage
{
    /// <summary>
    /// Инициализация страницы
    /// </summary>
    public AutoPartForClient()
	{
		InitializeComponent();
		BindingContext = new AutoPartForClientViewModel();
    }
}