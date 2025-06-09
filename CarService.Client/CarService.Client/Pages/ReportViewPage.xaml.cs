using CarService.Client.Others.DataServises;
using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// ����� �������� ��������� ������
/// </summary>
public partial class ReportViewPage : ContentPage
{
	/// <summary>
	/// ������������� ��������
	/// </summary>
	public ReportViewPage()
	{
        InitializeComponent();
		BindingContext = new ReportViewViewModel();

		WebViewPDF.Source = new Uri(ReportData.Path);
	}
}