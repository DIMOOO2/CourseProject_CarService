using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;
/// <summary>
/// ����� �������� �������� ������
/// </summary>
public partial class CreateWareousePage : ContentPage
{
    /// <summary>
    /// ����������� �������� �������� ������
    /// </summary>
    public CreateWareousePage()
	{
		InitializeComponent();
		BindingContext = new CreateWarehouseViewModel();
	}
}