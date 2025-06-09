using CarService.Client.Others.DataServises;
using CarService.Client.Others.Models;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarService.Client.ViewModels
{
    /// <summary>
    /// Класс модели представления для страницы отчетов по поставкам
    /// </summary>
    public partial class ArrivalsViewModel : ObservableObject
    {
        /// <summary>
        /// Список отчетов
        /// </summary>
        [ObservableProperty]
        ObservableCollection<ReportModel> deliveryReports;

        /// <summary>
        /// Выбранный отчет
        /// </summary>
        [ObservableProperty]
        ReportModel selectedReport;

        /// <summary>
        /// Свойство видимости логотипа пустой коллекции
        /// </summary>
        [ObservableProperty]
        private bool isVisibleEmptyLogo;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ArrivalsViewModel()
        {
            UpdateCollection();
        }

        /// <summary>
        /// Переход на страницу создания нового отчета о поступлении
        /// </summary>
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

        /// <summary>
        /// Обновление списка отчетов
        /// </summary>
        [RelayCommand]
        public async void UpdateCollection()
        {
            try
            {
                DeliveryReports = new ObservableCollection<ReportModel>();

                if (WebData.Reports == null)
                {
                    IsVisibleEmptyLogo = true;
                }
                else
                {
                    foreach (var item in WebData.Reports!)
                    {
                        DeliveryReports.Add(new ReportModel()
                        {
                            DeliveryReport = DeliveryReport.Create(item.ReportId, item.CreateDate,
                            item.WarehouseCreatorId, item.ReportFile).report
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                await Microsoft.Maui.Controls.Application.Current!.MainPage!.DisplayAlert("Ошибка", $"{ex.Message}", "ОК");
            }
        }
    }
}
