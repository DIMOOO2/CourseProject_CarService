using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class NewArrivalPage : ContentPage
{
	public NewArrivalPage()
	{
		InitializeComponent();
		BindingContext = new NewArrivalViewModel();
	}
}