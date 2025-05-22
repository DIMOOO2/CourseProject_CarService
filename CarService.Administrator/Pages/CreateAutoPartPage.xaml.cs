using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

public partial class CreateAutoPartPage : ContentPage
{
	public CreateAutoPartPage()
	{
		InitializeComponent();
		BindingContext = new CreateAutoPartViewModel();
	}
}