using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

/// <summary>
/// ����� �������� �������� �������
/// </summary>
public partial class CreateOrderPage : ContentPage
{
    /// <summary>
    /// ������������� ��������
    /// </summary>
    public CreateOrderPage()
	{
		InitializeComponent();
		BindingContext = new CreateOrderViewModel();
	}
}