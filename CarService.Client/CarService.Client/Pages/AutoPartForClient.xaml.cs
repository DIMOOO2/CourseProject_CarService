using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// ����� �������� ��������� ��� ��������
/// </summary>
public partial class AutoPartForClient : ContentPage
{
    /// <summary>
    /// ������������� ��������
    /// </summary>
    public AutoPartForClient()
	{
		InitializeComponent();
		BindingContext = new AutoPartForClientViewModel();
    }
}