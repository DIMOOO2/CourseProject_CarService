using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// Класс страницы обновления автозапчасти
/// </summary>
public partial class UpdateAutoPartPage : ContentPage
{
    /// <summary>
    /// Конструктор страницы обновления автозапчасти
    /// </summary>
    public UpdateAutoPartPage()
	{
		InitializeComponent();
		BindingContext = new UpdateAutoPartViewModel();
	}
}