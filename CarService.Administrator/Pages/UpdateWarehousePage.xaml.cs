using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// ����� �������� ���������� ������
/// </summary>
public partial class UpdateWarehousePage : ContentPage
{
    /// <summary>
    /// ����������� �������� ���������� ������
    /// </summary>
    public UpdateWarehousePage()
	{
		InitializeComponent();
        BindingContext = new UpdateWarehouseViewModel();
	}
}