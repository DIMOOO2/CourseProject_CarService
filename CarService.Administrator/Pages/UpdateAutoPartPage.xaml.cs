using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// ����� �������� ���������� ������������
/// </summary>
public partial class UpdateAutoPartPage : ContentPage
{
    /// <summary>
    /// ����������� �������� ���������� ������������
    /// </summary>
    public UpdateAutoPartPage()
	{
		InitializeComponent();
		BindingContext = new UpdateAutoPartViewModel();
	}
}