using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages;

/// <summary>
/// ����� �������� �������� ������������
/// </summary>
public partial class CreateAutoPartPage : ContentPage
{
    /// <summary>
    /// ����������� �������� �������� ������������
    /// </summary>
    public CreateAutoPartPage()
	{
		InitializeComponent();
		BindingContext = new CreateAutoPartViewModel();
	}
}