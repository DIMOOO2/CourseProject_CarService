using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// Класс страницы создания автозапчасти
/// </summary>
public partial class CreateAutoPartPage : ContentPage
{
    /// <summary>
    /// Конструктор страницы создания автозапчасти
    /// </summary>
    public CreateAutoPartPage()
	{
		InitializeComponent();
		BindingContext = new CreateAutoPartViewModel();
	}
}