using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

public partial class UpdateAutoPartPage : ContentPage
{
	public UpdateAutoPartPage()
	{
		InitializeComponent();
		BindingContext = new UpdateAutoPartViewModel();
	}
}