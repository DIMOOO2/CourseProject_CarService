using CarService.Client.Others.DataServises;
using CarService.Client.Pages;
using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarService.Client.Others.Models
{
    /// <summary>
    /// Класс модели отчета по поставке
    /// </summary>
    public partial class ReportModel : ObservableObject
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ReportModel() { }

        /// <summary>
        /// Отчет по поставке
        /// </summary>
        public DeliveryReport DeliveryReport { get; set; }

        /// <summary>
        /// метод открытия отчета на другой странице для отображения
        /// </summary>
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
