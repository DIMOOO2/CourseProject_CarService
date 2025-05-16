using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
		BindingContext = new ArrivalsViewModel();
	}
}