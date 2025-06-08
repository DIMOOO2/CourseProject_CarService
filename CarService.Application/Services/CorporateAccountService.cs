using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    /// <summary>
    /// Класс сервиса для работы с учетной записью склада
    /// </summary>
    public class CorporateAccountService : ICorporateAccountService
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="corporateAccountRepository">Интерфейс репозитория учетной записи</param>
        public CorporateAccountService(ICorporateAccountRepository corporateAccountRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
        }

        /// <summary>
        /// Получение всех учетных записей
        /// </summary>
        /// <returns></returns>
        public async Task<List<CorporateAccount>> GetAllAccounts()
        {
            return await _corporateAccountRepository.Get();
        }

        /// <summary>
        /// Получение учетной записи по ID
        /// </summary>
        /// <param name="id">ID учетной записи</param>
        /// <returns></returns>
        public async Task<CorporateAccount> GetByIdAccount(Guid id)
        {
            return await _corporateAccountRepository.GetById(id);
        }

        /// <summary>
        /// Создание учетной записи
        /// </summary>
        /// <param name="corporateAccount">Новая учетная запись</param>
        /// <returns></returns>
        public async Task<Guid> CreateAccount(CorporateAccount corporateAccount)
        {
            return await _corporateAccountRepository.Create(corporateAccount);
        }

        /// <summary>
        /// Обновление учетной записи
        /// </summary>
        /// <param name="accountId">ID учетной записи</param>
        /// <param name="logIn">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="warehouseId">ID Склада</param>
        /// <returns></returns>
        public async Task<Guid> UpdateAccount(Guid accountId, string logIn, string password, Guid warehouseId)
        {
            return await _corporateAccountRepository.Update(accountId, logIn, password, warehouseId);
        }

        /// <summary>
        /// Удаление учетной записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Guid> DeleteAccount(Guid id)
        {
            return await _corporateAccountRepository.Delete(id);
        }

        /// <summary>
        /// Получение учетной записи по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<CorporateAccount> FindWithProfile(string login, string password)
        {
            return await _corporateAccountRepository.GetWithLoginAndPassword(login, password);
        }
    }
}
