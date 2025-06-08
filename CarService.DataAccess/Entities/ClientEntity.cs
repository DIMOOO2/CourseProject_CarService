namespace CarService.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности клиента
    /// </summary>
    public class ClientEntity
    {
        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Отчество
        /// </summary>
        public string? MiddleName { get; set; } = string.Empty;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Город местонахождения
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// ID организации
        /// </summary>
        public Guid? OrganizationId { get; set; } 

        /// <summary>
        /// Организация
        /// </summary>
        public OrganizationEntity? Organization { get; set; }

        /// <summary>
        /// Список заказов
        /// </summary>
        public List<OrderEntity> Orders { get; set; } = [];
    }
}
