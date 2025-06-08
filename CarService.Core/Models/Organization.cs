namespace CarService.Core.Models
{
    /// <summary>
    /// Класс организации
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Число символов в ИНН
        /// </summary>
        const int COUNT_SYMBOLS_TIN = 10;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="organizationId">ID организации</param>
        /// <param name="titleOrganization">Название организации</param>
        /// <param name="tIN">ИНН</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        private Organization(Guid organizationId, string titleOrganization, long tIN, 
            string address, string city)
        {
            OrganizationId = organizationId;
            TitleOrganization = titleOrganization;
            TIN = tIN;
            Address = address;
            City = city;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Organization()
        {
        }

        /// <summary>
        /// ID организации
        /// </summary>
        public Guid OrganizationId { get; }

        /// <summary>
        /// Название организации
        /// </summary>
        public string TitleOrganization { get; } = string.Empty;

        /// <summary>
        /// ИНН
        /// </summary>
        public long TIN { get; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; } = string.Empty;

        /// <summary>
        /// Город местонахождения
        /// </summary>
        public string City { get; } = string.Empty;


        /// <summary>
        /// Метод инициализации новой организации
        /// </summary>
        /// <param name="organizationId">ID организации</param>
        /// <param name="titleOrganization">Название организации</param>
        /// <param name="tIN">ИНН</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <returns></returns>
        public static (Organization Organization, string error) Create(Guid organizationId, string titleOrganization, long tIN, string address, string city)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(titleOrganization) || string.IsNullOrEmpty(address)
                || string.IsNullOrEmpty(city) || tIN.ToString().Length != COUNT_SYMBOLS_TIN)
            {
                error = "Error organization is not created";
            }

            Organization organization = new Organization(organizationId, titleOrganization, tIN, address, city);

            return (organization, error);
        }
    }
}