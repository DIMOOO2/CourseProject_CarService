using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace CarService.Client.ViewModels
{
    public partial class ArrivalsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ReportModel> deliveryReports;

        [ObservableProperty]
        ReportModel selectedReport;

        public ArrivalsViewModel()
        {
            foreach(var item in WebData.Reports!)
            {
                DeliveryReports = new ObservableCollection<ReportModel>();
                DeliveryReports.Add(new ReportModel()
                {
                    DeliveryReport = DeliveryReport.Create(item.ReportId, item.CreateDate,
                    item.WarehouseCreatorId, item.ReportFile).report
                });
            }
        }

        [RelayCommand]
        public async void PushNewArrival()
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(NewArrivalPage));
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
