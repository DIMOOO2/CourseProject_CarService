namespace CarService.Core.Models
{
    /// <summary>
    /// Класс производителя
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="manufacturerId">ID производителя</param>
        /// <param name="manufacturerName">Название производителя</param>
        /// <param name="contactInfo">Контактная информация</param>
        private Manufacturer(Guid manufacturerId, string manufacturerName, string contactInfo)
        {
            ManufacturerId = manufacturerId;
            ManufacturerName = manufacturerName;
            ContactInfo = contactInfo;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Manufacturer()
        {      
        }

        /// <summary>
        /// ID производителя
        /// </summary>
        public Guid ManufacturerId { get; }

        /// <summary>
        /// Название производителя
        /// </summary>
        public string ManufacturerName { get; } = string.Empty;

        /// <summary>
        /// Контактная информация
        /// </summary>
        public string ContactInfo { get; } = string.Empty;


        /// <summary>
        /// Метод инициализации нового производителя
        /// </summary>
        /// <param name="id">ID производителя</param>
        /// <param name="name">Название производителя</param>
        /// <param name="contactInfo">Контактная информация</param>
        /// <returns></returns>
        public static (Manufacturer Manufacturer, string error) Create(Guid id, string name, string contactInfo)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contactInfo))
            {
                error = "Error manufacturer is not created";
            }

            Manufacturer manufacturer = new Manufacturer(id, name, contactInfo);

            return (manufacturer, error);
        }
    }
}
