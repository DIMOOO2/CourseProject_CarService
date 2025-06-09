using CarService.Core.Models;


namespace CarService.Client.Others.DataServises
{
    /// <summary>
    /// Класс данных при авторизации в приложении
    /// </summary>
    public static class LoginData
    {
        /// <summary>
        /// Текущий склад который закреплен за учетной записью приложением
        /// </summary>
        public static Warehouse? CurrentWarehouse { get; set; }

        /// <summary>
        /// Метод установки текущего склада
        /// </summary>
        /// <param name="warehouse">Текущий склад</param>
        public static void SetWarehouse(Warehouse? warehouse)
        {
            CurrentWarehouse = warehouse;
        }
    }
}
