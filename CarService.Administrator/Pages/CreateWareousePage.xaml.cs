using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

public partial class CreateWareousePage : ContentPage
{
	public CreateWareousePage()
	{
		InitializeComponent();
		BindingContext = new CreateWarehouseViewModel();
	}
}