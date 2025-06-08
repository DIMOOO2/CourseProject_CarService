using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для работы с корпоративными аккаунтами
    /// </summary>
    public interface ICorporateAccountService
    {
        /// <summary>
        /// Создание корпоративного аккаунта
        /// </summary>
        /// <param name="corporateAccount">Новый корпоративный аккаунт</param>
        /// <returns></returns>
        Task<Guid> CreateAccount(CorporateAccount corporateAccount);

        /// <summary>
        /// Удаление корпоративного аккаунта
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <returns></returns>
        Task<Guid> DeleteAccount(Guid id);

        /// <summary>
        /// Получение корпоративного аккаунта по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<CorporateAccount> FindWithProfile(string login, string password);

        /// <summary>
        /// Получение всех корпоративных аккаунтов
        /// </summary>
        /// <returns></returns>
        Task<List<CorporateAccount>> GetAllAccounts();

        /// <summary>
        /// Получение корпоративных аккаунтов по ID
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <returns></returns>
        Task<CorporateAccount> GetByIdAccount(Guid id);

        /// <summary>
        /// Обновление корпоративного аккаунта
        /// </summary>
        /// <param name="accountId">ID аккаунта</param>
        /// <param name="logIn">Новый логин</param>
        /// <param name="password">Новый пароль</param>
        /// <param name="warehouseId">Новый ID склада</param>
        /// <returns></returns>
        Task<Guid> UpdateAccount(Guid accountId, string logIn, string password, Guid warehouseId);
    }
}