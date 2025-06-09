using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// Класс страницы нового постуления на склад
/// </summary>
public partial class NewArrivalPage : ContentPage
{
    /// <summary>
    /// Инициализация страницы
    /// </summary>
    public NewArrivalPage()
	{
		InitializeComponent();
		BindingContext = new NewArrivalViewModel();
	}
}