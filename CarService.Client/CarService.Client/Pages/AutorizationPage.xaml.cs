using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// ����� �������� �����������
/// </summary>
public partial class AutorizationPage : ContentPage
{
    /// <summary>
    /// ������������� ��������
    /// </summary>
    public AutorizationPage()
	{
		InitializeComponent();
		BindingContext = new AutorizationViewModel();
	}
}