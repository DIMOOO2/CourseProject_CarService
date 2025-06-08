namespace CarService.Core.Models
{
    /// <summary>
    /// Класс клиента
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <param name="organizationId">ID организации</param>
        private Client(Guid clientId, string firstName, string lastName, string? middleName, 
            string phoneNumber, string email, string address, string city, Guid? organizationId)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            City = city;
            OrganizationId = organizationId;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Client()
        {         
        }

        /// <summary>
        /// ID клиента
        /// </summary>
        public Guid ClientId { get; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string FirstName { get; } = string.Empty;

        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string LastName { get; } = string.Empty;

        /// <summary>
        /// Отчество клиента
        /// </summary>
        public string? MiddleName { get; } = string.Empty;

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public string PhoneNumber { get; } = string.Empty;

        /// <summary>
        /// Электронная почта клиента
        /// </summary>
        public string Email { get; } = string.Empty;

        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string Address { get; } = string.Empty;

        /// <summary>
        /// Город местонахождения клиента
        /// </summary>
        public string City { get; } = string.Empty;

        /// <summary>
        /// ID организации-клиента
        /// </summary>
        public Guid? OrganizationId { get; }

        /// <summary>
        /// ФИО клиента полностью
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName} {MiddleName}";
            }
        }

        /// <summary>
        /// Метод инициализации нового клиента
        /// </summary>
        /// <param name="clientId">ID клиента</param>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="middleName">Отчество</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="address">Адрес</param>
        /// <param name="city">Город</param>
        /// <param name="organization">ID организации</param>
        /// <returns></returns>
        public static (Client Client, string error) Create(Guid clientId, string firstName, 
            string lastName, string? middleName,
            string phoneNumber, string email, string address, string city, Guid? organization)
        {
            string error = string.Empty;

            string[] requiredParams = { firstName, lastName, phoneNumber, email, address, city};

            foreach(string param in requiredParams)
            {
                if (string.IsNullOrEmpty(param))
                {
                    error = "Error client is not created";
                    break;
                }                                    
            }

            Client client = new Client(clientId, firstName, lastName, middleName, 
                phoneNumber, email, address, city, organization);

            return (client, error);
        }
    }
}
