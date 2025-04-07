using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class SearchAutoPart : ContentPage
{
	public SearchAutoPart()
	{
		InitializeComponent();
		BindingContext = new SearchAutoPartViewModel();
	}
}