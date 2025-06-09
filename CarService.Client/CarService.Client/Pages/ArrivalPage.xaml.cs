using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// Класс страницы Заказов
/// </summary>
public partial class OrderPage : ContentPage
{
	/// <summary>
	/// Инициализация страницы
	/// </summary>
	public OrderPage()
	{
		InitializeComponent();
		BindingContext = new ArrivalsViewModel();
	}
}