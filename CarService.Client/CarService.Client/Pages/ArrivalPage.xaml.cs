using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// ����� �������� �������
/// </summary>
public partial class OrderPage : ContentPage
{
	/// <summary>
	/// ������������� ��������
	/// </summary>
	public OrderPage()
	{
		InitializeComponent();
		BindingContext = new ArrivalsViewModel();
	}
}