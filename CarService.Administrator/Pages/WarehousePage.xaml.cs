using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;
/// <summary>
/// ����� �������� �������
/// </summary>
public partial class WarehousePage : ContentPage
{
    /// <summary>
    /// ����������� �������� �������
    /// </summary>
    public WarehousePage()
	{
		InitializeComponent();
		BindingContext = new WarehousesViewModel();
	}
}