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
using System.Net.Http.Json;
using CarService.ApplicationService.Contracts.Requests;
using QuestPDF.Previewer;
using CarService.ApplicationService.Contracts.Responses;


namespace CarService.Client.ViewModels
{
    public partial class NewArrivalViewModel : ObservableObject
    {
        private HttpClient _httpClient = new HttpClient();

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
            try
            {
                AutoPartsFromArrival = new ObservableCollection<ArrivalAutoPart>();
                AllAutoParts = new ObservableCollection<AutoPartInfo>();
                foreach (var autoPart in WebData.AutoParts!)
                {
                    AllAutoParts.Add(new AutoPartInfo(autoPart.AutoPartId, autoPart.AutoPartName,
                        autoPart.PartNumber, autoPart.Price, autoPart.StockAmount, autoPart.ManufacturerId, autoPart.WarehouseId));
                }
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private void AddArrivalCollection()
        {
            try
            {
                if (SelectedAutoPartFromAll != null)
                {
                    AutoPartsFromArrival.Add(new ArrivalAutoPart() { AutoPart = SelectedAutoPartFromAll });
                    AllAutoParts.Remove(SelectedAutoPartFromAll);
                }

                else return;
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        [RelayCommand]
        private void RemoveArrivalCollection() 
        {
            try
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
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
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

                DateTime dateTime = DateTime.Now;
                var document = new ReportDocument(numberReport, dateTime, AutoPartsFromArrival, LoginData.CurrentWarehouse!);

                var documentByte = document.GeneratePdf();

                using var response = await _httpClient.PostAsJsonAsync<DeliveryReportRequest>("https://localhost:1488/DeliveryReport", new DeliveryReportRequest(guid, dateTime, LoginData.CurrentWarehouse!.WarehouseId, documentByte));

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    DeliveryReportResponse? reportResponse = await response.Content.ReadFromJsonAsync<DeliveryReportResponse>();
                    WebData.GetColllectionReport(await _httpClient.GetFromJsonAsync<List<DeliveryReportResponse>>("https://localhost:1488/DeliveryReport"));
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Отчет создан. Номер отчета {reportResponse!.reportId}", "ОК");


                    await Shell.Current.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", ex.Message, "ОК");
            }
        }
    }
}