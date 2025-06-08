namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности организации
    /// </summary>
    public class OrganizationEntity
    {
        /// <summary>
        /// ID организации
        /// </summary>
        public Guid OrganizationId { get; set; }

        /// <summary>
        /// Название организации
        /// </summary>
        public string TitleOrganization { get; set; } = string.Empty;

        /// <summary>
        /// ИНН
        /// </summary>
        public long TIN { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Город местоположения
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Список клиентов, работащих в данной организации
        /// </summary>
        public List<ClientEntity> Clients { get; set; } = [];
    }
}
