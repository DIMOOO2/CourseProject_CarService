using CarService.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarService.Client.Others.Models
{
    /// <summary>
    /// Класс автозапчасти в корзине
    /// </summary>
    public partial class CartAutoPart : ObservableObject
    {
        /// <summary>
        /// Желаемое количество в корзине заказа
        /// </summary>
        [ObservableProperty]
        private uint desiredCount;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="countWithFutureOrder">Количество желаемой автозапчасти</param>
        public CartAutoPart(uint countWithFutureOrder = 1)
        {
            DesiredCount = countWithFutureOrder;
        }

        /// <summary>
        /// Автозапчасть
        /// </summary>
        public AutoPart AutoPart { get; set; } = null!;

        /// <summary>
        /// Метод увеличения количества на 1
        /// </summary>
        [RelayCommand]
        private void AddDisiredCount()
        {
            if (AutoPart.StockAmount > DesiredCount)
                DesiredCount++;
        }

        /// <summary>
        /// Метод уменьшения количества на 1
        /// </summary>
        [RelayCommand]
        private void DiffDisiredCount()
        {
            if (DesiredCount > 1)
                DesiredCount--;
        }
    }
}
