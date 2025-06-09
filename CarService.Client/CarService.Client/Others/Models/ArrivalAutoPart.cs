using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarService.Client.Others.Models
{
    /// <summary>
    /// Класс автозапчасти в поступлении
    /// </summary>
    public partial class ArrivalAutoPart : ObservableObject
    {
        /// <summary>
        /// Количество запчастей
        /// </summary>
        [ObservableProperty]
        private uint desiredCount;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public ArrivalAutoPart()
        {
            DesiredCount = 1;
        }

        /// <summary>
        /// Информация об автозапчасти
        /// </summary>
        public AutoPartInfo AutoPart { get; set; } = null!;

        /// <summary>
        /// Свойство количества автозапчастей в поступлении
        /// </summary>
        public uint СountWithArrival => DesiredCount;

        /// <summary>
        /// Метод увеличения количества на 1
        /// </summary>
        [RelayCommand]
        private void AddArrivalAutoPartCount()
        {
            DesiredCount++;
        }

        /// <summary>
        /// Метод уменьшения количества на 1
        /// </summary>
        [RelayCommand]
        private void DiffArrivalAutoPartCount()
        {
            if (DesiredCount > 1)
                DesiredCount--;
        }
    }
}
