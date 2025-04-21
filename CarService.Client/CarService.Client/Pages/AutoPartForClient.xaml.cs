using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class AutoPartForClient : ContentPage
{
	public AutoPartForClient()
	{
		InitializeComponent();
		BindingContext = new AutoPartForClientViewModel();
    }
}