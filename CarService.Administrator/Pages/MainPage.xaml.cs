using CarService.Administrator.ViewModels;

namespace CarService.Administrator.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AutoPartsViewModelAdmin();
        }
    }
}
