using CommunityToolkit.Mvvm.ComponentModel;

namespace CarService.Client.ViewModels
{
    /// <summary>
    /// Класс модели представления просмотра отчета о поступлении
    /// </summary>
    public partial class ReportViewViewModel : ObservableObject
    {
        /// <summary>
        /// Путь к файлу отчета
        /// </summary>
        [ObservableProperty]
        private string path;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ReportViewViewModel()
        {
        }
    }
}
