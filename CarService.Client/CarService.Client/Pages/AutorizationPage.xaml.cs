using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class AutorizationPage : ContentPage
{
	public AutorizationPage()
	{
		InitializeComponent();
		BindingContext = new AutorizationViewModel();
	}
}