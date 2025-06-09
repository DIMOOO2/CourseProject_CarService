using CarService.ApplicationService.Contracts.Responses;
using System.Collections.ObjectModel;


namespace CarService.Client.Others.DataServises
{
    /// <summary>
    /// Класс данных автозапчасти в корзине
    /// </summary>
    public static class CartData
    {
        /// <summary>
        /// Список корзины автозапчастей
        /// </summary>
        public static ObservableCollection<AutoPartResponse>? AutoParts { get; set; }

        /// <summary>
        /// Метод установления нового списка корзины
        /// </summary>
        /// <param name="autoParts">Новый список автозапчасти</param>
        public static void SetCart(ObservableCollection<AutoPartResponse>? autoParts)
        {
            AutoParts = autoParts;  
        }
    }
}
