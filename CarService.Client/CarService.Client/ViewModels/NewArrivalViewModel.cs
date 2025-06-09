using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using CarService.Client.Others.PdfWorkers.DataSourse;
using System.Net.Http.Json;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using CarService.Core.Models;


namespace CarService.Client.ViewModels
{
    /// <summary>
    /// Класс представления страницы оформления нового поступления
    /// </summary>
    public partial class NewArrivalViewModel : ObservableObject
    {
        /// <summary>
        /// Новый Http-клиент
        /// </summary>
        private HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Список всех автозапчастей на складе
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<AutoPartInfo> allAutoParts;

        /// <summary>
        /// Список автозапчастей в поставке
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<ArrivalAutoPart> autoPartsFromArrival;

        /// <summary>
        /// Выбранный элемент в списке запчастей на складе
        /// </summary>
        [ObservableProperty]
        private AutoPartInfo? selectedAutoPartFromAll;
        
        /// <summary>
        /// Выбранный элемент в списке автозапчастей в поставке
        /// </summary>
        [ObservableProperty]
        private ArrivalAutoPart? selectedAutoPartFromArrival;

        /// <summary>
        /// Количество автозапчасти в поступлении
        /// </summary>
        [ObservableProperty]
        private string autoPartAmountStr;

        /// <summary>
        /// Поле количества автозапчастей в поступлении
        /// </summary>
        private uint autoPartAmount = 0;

        /// <summary>
        /// Конструктор класса
        /// </summary>
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

        /// <summary>
        /// Добаление автозапчасти в список поступления
        /// </summary>
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

        /// <summary>
        /// Удаление автозапчасти из списка поступления
        /// </summary>
        [RelayCommand]
        private void RemoveArrivalCollection() 
        {
            try
            {
                if (SelectedAutoPartFromArrival != null)
                {        
                    AllAutoParts.Add(new AutoPartInfo(
                        SelectedAutoPartFromArrival.AutoPart.AutoPartId,
                        SelectedAutoPartFromArrival.AutoPart.AutoPartName,
                        SelectedAutoPartFromArrival.AutoPart.PartNumber,
                        SelectedAutoPartFromArrival.AutoPart.Price,
                        SelectedAutoPartFromArrival.AutoPart.StockAmount,
                        SelectedAutoPartFromArrival.AutoPart.ManufacturerId,
                        SelectedAutoPartFromArrival.AutoPart.WarehouseId
                        ));
                    AutoPartsFromArrival.Remove(SelectedAutoPartFromArrival!);
                }
                else return;
            }
            catch (Exception ex)
            {
                Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }

        /// <summary>
        /// Новый ID отчета
        /// </summary>
        private Guid guid = Guid.NewGuid();
        
        /// <summary>
        /// Сохранение отчета
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task SaveArrival()
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                byte[] data = guid.ToByteArray();


                long numberReport = Convert.ToInt64(Math.Abs(BitConverter.ToInt32(data, 0)));

                DateTime dateTime = DateTime.Now;
                var document = new ReportDocument(numberReport, dateTime, AutoPartsFromArrival, LoginData.CurrentWarehouse!);

                var documentByte = document.GeneratePdf();

                using var response = await _httpClient.PostAsJsonAsync<DeliveryReportRequest>("https://localhost:1488/DeliveryReport", new DeliveryReportRequest(guid, dateTime, LoginData.CurrentWarehouse!.WarehouseId, documentByte));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    DeliveryReportResponse? reportResponse = await response.Content.ReadFromJsonAsync<DeliveryReportResponse>();
                    WebData.GetColllectionReport(await _httpClient.GetFromJsonAsync<List<DeliveryReportResponse>>("https://localhost:1488/DeliveryReport"));
                    await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Сообщение", $"Отчет создан. Номер отчета {DeliveryReport.Create
                        (
                            reportResponse!.reportId,
                            reportResponse.createDate,
                            reportResponse.warehouseCreatorId,
                            reportResponse.fileReport
                        )
                        .report.GetReportArticul}", "ОК");

                    foreach (var item in AutoPartsFromArrival)
                    {
                        var responseUpdate = await _httpClient.PutAsJsonAsync<AutoPartRequest>($"https://localhost:1488/AutoPart/{item.AutoPart.AutoPartId}",
                            new AutoPartRequest
                            (
                                item.AutoPart.AutoPartName,
                                item.AutoPart.PartNumber,
                                item.AutoPart.Price,
                                item.AutoPart.StockAmount + item.СountWithArrival,
                                item.AutoPart.ManufacturerId,
                                item.AutoPart.WarehouseId
                            ));
                    }
                    WebData.GetColllectionReport(await _httpClient.GetFromJsonAsync<List<DeliveryReportResponse>>($"https://localhost:1488/DeliveryReport/fromWarehouse/{LoginData.CurrentWarehouse.WarehouseId}"));

                    var autoPartResponses = await _httpClient.GetFromJsonAsync<List<AutoPartResponse>>($"https://localhost:1488/AutoPart");

                    WebData.GetAutoPartsCollection(autoPartResponses);

                    await Shell.Current.Navigation.PopAsync();

                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", ex.Message, "ОК");
                await _httpClient.DeleteFromJsonAsync<DeliveryReportRequest>($"https://localhost:1488/DeliveryReport/{guid}");
            }
        }
    }
}