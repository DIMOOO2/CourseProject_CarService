using CarService.Client.Others.DataServises;
using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// Класс страницы просмотра отчета
/// </summary>
public partial class ReportViewPage : ContentPage
{
	/// <summary>
	/// Инициализация страницы
	/// </summary>
	public ReportViewPage()
	{
        InitializeComponent();
		BindingContext = new ReportViewViewModel();

		WebViewPDF.Source = new Uri(ReportData.Path);
	}
}