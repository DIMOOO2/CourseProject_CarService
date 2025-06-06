using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// Класс страницы заказов
/// </summary>
public partial class OrdersPage : ContentPage
{
    /// <summary>
    /// Конструктор страницы заказов
    /// </summary>
    public OrdersPage()
	{
		InitializeComponent();
		BindingContext = new OrdersViewModel();
	}
}