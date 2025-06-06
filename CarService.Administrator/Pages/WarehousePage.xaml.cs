using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;
/// <summary>
/// Класс страницы складов
/// </summary>
public partial class WarehousePage : ContentPage
{
    /// <summary>
    /// Конструктор страницы складов
    /// </summary>
    public WarehousePage()
	{
		InitializeComponent();
		BindingContext = new WarehousesViewModel();
	}
}