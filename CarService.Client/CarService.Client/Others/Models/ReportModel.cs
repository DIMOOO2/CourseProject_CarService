using CarService.Client.Others.DataServises;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;




namespace CarService.Client.Others.Models
{
    public partial class ReportModel : ObservableObject
    {
        public ReportModel() { }

        public DeliveryReport DeliveryReport { get; set; }

        [RelayCommand]
        private async void OpenReport()
        {
            try
            {
                string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "temp.pdf");

                File.WriteAllBytes(filePath, DeliveryReport.ReportFile);

                ReportData.SetPath(filePath);

                await Shell.Current.GoToAsync(nameof(ReportViewPage));
            }
            catch (Exception ex) 
            {
                await Application.Current!.MainPage!.DisplayAlert("Сообщение", ex.Message, "OK");
            }
        }
    }
}
