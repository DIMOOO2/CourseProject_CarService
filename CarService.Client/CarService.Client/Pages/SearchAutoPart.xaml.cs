using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// ����� �������� ������ ���������
/// </summary>
public partial class SearchAutoPart : ContentPage
{
	/// <summary>
	/// ������������� ��������
	/// </summary>
	public SearchAutoPart()
	{
		InitializeComponent();
		BindingContext = new SearchAutoPartViewModel();
	}
}