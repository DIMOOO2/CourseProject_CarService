using CarService.Core.Models;

namespace CarService.Administrator.Others.Data
{
    /// <summary>
    /// Класс для данных, которыми пользуются всё приложение администратора
    /// </summary>
    public static class AdminLocalData
    {
        /// <summary>
        /// Свойство текущей автозачасти, у которой можно получить данные
        /// </summary>
        public static AutoPart CurrentAutoPart { get; set; } = null!;
        /// <summary>
        /// Свойство производителя у текущей автозапчасти
        /// </summary>
        public static Manufacturer CurrentManufacturer { get; set; } = null!;

        /// <summary>
        /// Выбор новой текущей автозапчасти
        /// </summary>
        /// <param name="temp">Автозачасть, у которой можно получить данные</param>
        public static void SetAutoPart(AutoPart temp)
        {
            CurrentAutoPart = temp;
            CurrentManufacturer = WebData.Manufacturers!.FirstOrDefault(m => m.ManufacturerId == temp.ManufacturerId)!;
        }
        /// <summary>
        /// Выбор нового текущего склада
        /// </summary>
        /// <param name="temp">Новый склад</param>
        public static void SetWarehouse(Warehouse temp)
        {
            //TODO: нужно для логики обновления склада
        }
    }
}