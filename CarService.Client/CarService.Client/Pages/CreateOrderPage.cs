using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class CreateOrderPage : ContentPage
{
	public CreateOrderPage()
	{
		InitializeComponent();
		BindingContext = new CreateOrderViewModel();
	}
}