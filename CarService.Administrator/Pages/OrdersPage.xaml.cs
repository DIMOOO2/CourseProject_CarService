using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// ����� �������� �������
/// </summary>
public partial class OrdersPage : ContentPage
{
    /// <summary>
    /// ����������� �������� �������
    /// </summary>
    public OrdersPage()
	{
		InitializeComponent();
		BindingContext = new OrdersViewModel();
	}
}