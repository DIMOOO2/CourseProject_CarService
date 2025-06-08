namespace CarService.Core.Models
{
    /// <summary>
    /// Класс корпоративного аккаунта
    /// </summary>
    public class CorporateAccount
    {
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="accountId">ID аккаунта</param>
        /// <param name="logIn">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="warehouseId">ID склада</param>
        private CorporateAccount(Guid accountId, string logIn, string password, Guid warehouseId)
        {
            AccountId = accountId;
            LogIn = logIn;
            Password = password;
            WarehouseId = warehouseId;
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public CorporateAccount()
        {
        }

        /// <summary>
        /// ID аккаунта
        /// </summary>
        public Guid AccountId { get; }

        /// <summary>
        /// Логин
        /// </summary>
        public string LogIn { get; } = null!;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; } = null!;

        /// <summary>
        /// ID склада
        /// </summary>
        public Guid WarehouseId { get; }

        /// <summary>
        /// Метод инициализации нового корпоративного аккаунта
        /// </summary>
        /// <param name="accountId">ID аккаунта</param>
        /// <param name="logIn">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="warehouse">ID склада</param>
        /// <returns></returns>
        public static (CorporateAccount CorporateAccount, string error) Create(Guid accountId, string logIn, string password, Guid warehouse)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(logIn) || string.IsNullOrEmpty(password)
                || warehouse == Guid.Empty)
            {
                error = "Error account is not created";
            }

            CorporateAccount corporateAccount = new CorporateAccount(accountId, logIn, password, warehouse!);

            return (corporateAccount, error);
        }
    }
}
