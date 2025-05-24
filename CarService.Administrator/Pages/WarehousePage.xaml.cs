using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

public partial class WarehousePage : ContentPage
{
	public WarehousePage()
	{
		InitializeComponent();
		BindingContext = new WarehousesViewModel();
	}
}