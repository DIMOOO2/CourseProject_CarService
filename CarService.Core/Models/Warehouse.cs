namespace CarService.Core.Models
{
    /// <summary>
    /// Класс склада
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="warehouseId">ID склада</param>
        /// <param name="title">Название</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город местоположения</param>
        private Warehouse(Guid warehouseId, string title, string address, string city)
        {
            WarehouseId = warehouseId;
            Title = title;
            Address = address;
            City = city;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Warehouse()
        {
        }

        /// <summary>
        /// ID склада
        /// </summary>
        public Guid WarehouseId { get; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; } = string.Empty;

        /// <summary>
        /// Город местоположения
        /// </summary>
        public string City { get; } = string.Empty;


        /// <summary>
        /// Метод инициализации нового склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <param name="title">Название</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город местоположения</param>
        /// <returns></returns>
        public static (Warehouse Warehouse, string error) Create(Guid id, string title, string address, string city)
        {
            string error = string.Empty;

            if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(address) 
                || string.IsNullOrEmpty(city))
            {
                error = "Error warehouse is not created";
            }

            Warehouse warehouse = new Warehouse(id, title, address, city);

            return (warehouse, error);
        }

        /// <summary>
        /// Переопределенный метод, возвращающий полную информацию о складе
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Title}. Адрес: {City} {Address}";
        }
    }
}
