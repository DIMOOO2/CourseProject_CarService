namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности производителя
    /// </summary>
    public class ManufacturerEntity
    {
        /// <summary>
        /// ID производителя
        /// </summary>
        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Название производителя
        /// </summary>
        public string ManufacturerName { get; set; } = string.Empty;

        /// <summary>
        /// Контактная информация
        /// </summary>
        public string ContactInfo { get; set;  } = string.Empty;

        /// <summary>
        /// Список автозапчастей, произведенных этим производителем
        /// </summary>
        public List<AutoPartEntity> AutoParts { get; set; } = [];
    }
}
