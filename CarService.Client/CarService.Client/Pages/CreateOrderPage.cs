using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// Класс страницы создания заказов
/// </summary>
public partial class CreateOrderPage : ContentPage
{
    /// <summary>
    /// Инициализация страницы
    /// </summary>
    public CreateOrderPage()
	{
		InitializeComponent();
		BindingContext = new CreateOrderViewModel();
	}
}