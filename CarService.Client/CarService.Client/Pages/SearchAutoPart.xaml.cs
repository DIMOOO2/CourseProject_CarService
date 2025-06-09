using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// Класс страницы поиска запчастей
/// </summary>
public partial class SearchAutoPart : ContentPage
{
	/// <summary>
	/// Инициализация страницы
	/// </summary>
	public SearchAutoPart()
	{
		InitializeComponent();
		BindingContext = new SearchAutoPartViewModel();
	}
}