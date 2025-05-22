using CarService.Client.Others.DataServises;
using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class ReportViewPage : ContentPage
{
	public ReportViewPage()
	{
        InitializeComponent();
		BindingContext = new ReportViewViewModel();

		WebViewPDF.Source = new Uri(ReportData.Path);
	}
}