using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarService.Client.ViewModels
{
    public partial class ReportViewViewModel : ObservableObject
    {
        [ObservableProperty]
        private string path;

        public ReportViewViewModel()
        {
        }

        [RelayCommand]
        private void SaveDocument()
        {
            
        }
    }
}
