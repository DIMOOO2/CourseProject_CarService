using CarService.Client.ViewModels;

namespace CarService.Client.Pages;
/// <summary>
/// ����� �������� ������ ���������� �� �����
/// </summary>
public partial class NewArrivalPage : ContentPage
{
    /// <summary>
    /// ������������� ��������
    /// </summary>
    public NewArrivalPage()
	{
		InitializeComponent();
		BindingContext = new NewArrivalViewModel();
	}
}