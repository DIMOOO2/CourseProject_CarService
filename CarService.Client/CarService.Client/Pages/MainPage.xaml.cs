using CarService.Client.Others.LoginData;
using CarService.Client.ViewModels;

namespace CarService.Client.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}
