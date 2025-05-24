using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

public partial class OrdersPage : ContentPage
{
	public OrdersPage()
	{
		InitializeComponent();
		BindingContext = new OrdersViewModel();
	}
}