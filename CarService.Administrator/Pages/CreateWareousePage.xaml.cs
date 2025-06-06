using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;
/// <summary>
/// Класс страницы создания склада
/// </summary>
public partial class CreateWareousePage : ContentPage
{
    /// <summary>
    /// Конструктор страницы создания склада
    /// </summary>
    public CreateWareousePage()
	{
		InitializeComponent();
		BindingContext = new CreateWarehouseViewModel();
	}
}