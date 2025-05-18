using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.IO;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using CarService.Client.Others.PdfWorkers.DataSourse;


namespace CarService.Client.ViewModels
{
    public partial class NewArrivalViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AutoPartInfo> allAutoParts;

        [ObservableProperty]
        private ObservableCollection<ArrivalAutoPart> autoPartsFromArrival;

        [ObservableProperty]
        private AutoPartInfo? selectedAutoPartFromAll;
        
        [ObservableProperty]
        private ArrivalAutoPart? selectedAutoPartFromArrival;

        [ObservableProperty]
        private string autoPartAmountStr;

        private uint autoPartAmount = 0;

        public NewArrivalViewModel()
        {
            AutoPartsFromArrival = new ObservableCollection<ArrivalAutoPart>();
            AllAutoParts = new ObservableCollection<AutoPartInfo>();
            foreach (var autoPart in WebData.AutoParts!)
            {
                AllAutoParts.Add(new AutoPartInfo(autoPart.AutoPartId, autoPart.AutoPartName,
                    autoPart.PartNumber, autoPart.Price, autoPart.StockAmount, autoPart.ManufacturerId, autoPart.WarehouseId));
            }
        }

        [RelayCommand]
        private void AddArrivalCollection()
        {
            if (SelectedAutoPartFromAll != null)
            {
                AutoPartsFromArrival.Add(new ArrivalAutoPart() { AutoPart = SelectedAutoPartFromAll });
                AllAutoParts.Remove(SelectedAutoPartFromAll);
            }
                
            else return;
        }

        [RelayCommand]
        private void RemoveArrivalCollection() 
        {
            if (SelectedAutoPartFromArrival != null)
            {
                AutoPartsFromArrival.Remove(SelectedAutoPartFromArrival!);
                AllAutoParts.Add(new AutoPartInfo(
                    SelectedAutoPartFromArrival.AutoPart.AutoPartId,
                    SelectedAutoPartFromArrival.AutoPart.AutoPartName,
                    SelectedAutoPartFromArrival.AutoPart.PartNumber,
                    SelectedAutoPartFromArrival.AutoPart.Price,
                    SelectedAutoPartFromArrival.AutoPart.StockAmount,
                    SelectedAutoPartFromArrival.AutoPart.ManufacturerId,
                    SelectedAutoPartFromArrival.AutoPart.WarehouseId
                    ));
            }
            else return;
        }

        [RelayCommand]
        private async Task SaveArrival()
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                Guid guid = Guid.NewGuid();
                byte[] data = guid.ToByteArray();

                long numberReport = Convert.ToInt64(Math.Abs(BitConverter.ToInt32(data, 0)));
                var document = new ReportDocument(numberReport, DateTime.Now, AutoPartsFromArrival, LoginData.CurrentWarehouse!);

                document.GeneratePdfAndShow();
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", ex.Message, "ОК");
            }
        }
    }
}