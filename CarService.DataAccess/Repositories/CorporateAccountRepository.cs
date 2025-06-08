using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий корпоративных аккаунтов
    /// </summary>
    public class CorporateAccountRepository : ICorporateAccountRepository
    {
        private readonly CarServiceDbContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public CorporateAccountRepository(CarServiceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех корпоративных аккаунтов
        /// </summary>
        /// <returns></returns>
        public async Task<List<CorporateAccount>> Get()
        {
            var accountEntities = await _context.CorporateAccounts
                .AsNoTracking()
                .ToListAsync();

            var accounts = accountEntities
                .Select(ca => CorporateAccount.Create(ca.AccountId, ca.LogIn, ca.Password, ca.WarehouseId)
                .CorporateAccount)
                .ToList();

            return accounts;
        }

        /// <summary>
        /// Получение корпоративных аккаунтов по ID
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <returns></returns>
        public async Task<CorporateAccount> GetById(Guid id)
        {
            var accountEntity = await _context.CorporateAccounts.FirstOrDefaultAsync(c => c.AccountId == id);
            if (accountEntity != null)
            {
                var account = CorporateAccount.Create(accountEntity.AccountId, accountEntity.LogIn,
                    accountEntity.Password, accountEntity.WarehouseId)
                .CorporateAccount;

                return account;
            }

            else return null!;
        }

        /// <summary>
        /// Получение корпоративного аккаунта по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task<CorporateAccount> GetWithLoginAndPassword(string login, string password)
        {
            var account = await _context.CorporateAccounts.FirstOrDefaultAsync(a => a.LogIn == login && a.Password == password);

            if (account == null)
                return null!;

            else
            {
                return CorporateAccount.Create(account.AccountId, 
                    account.LogIn,
                    account.Password, 
                    account.WarehouseId).CorporateAccount;
            }
                
        }

        /// <summary>
        /// Создание корпоративного аккаунта
        /// </summary>
        /// <param name="corporateAccount">Новый корпоративный аккаунт</param>
        /// <returns></returns>
        public async Task<Guid> Create(CorporateAccount corporateAccount)
        {
            CorporateAccountEntity corporateAccountEntity = new CorporateAccountEntity()
            {
                AccountId = corporateAccount.AccountId,
                LogIn = corporateAccount.LogIn,
                Password = corporateAccount.Password,
                WarehouseId = corporateAccount.WarehouseId
            };

            await _context.CorporateAccounts.AddAsync(corporateAccountEntity);
            await _context.SaveChangesAsync();

            return corporateAccountEntity.AccountId;
        }

        /// <summary>
        /// Обновление корпоративного аккаунта
        /// </summary>
        /// <param name="accountId">ID аккаунта</param>
        /// <param name="logIn">Новый логин</param>
        /// <param name="password">Новый пароль</param>
        /// <param name="warehouseId">Новый ID склада</param>
        /// <returns></returns>
        public async Task<Guid> Update(Guid accountId, string logIn, string password, Guid warehouseId)
        {
            await _context.CorporateAccounts
                .Where(ca => ca.AccountId == accountId)
                .ExecuteUpdateAsync(u => u
                .SetProperty(ca => ca.LogIn, logIn)
                .SetProperty(ca => ca.Password, password)
                .SetProperty(ca => ca.WarehouseId, warehouseId));

            return accountId;
        }

        /// <summary>
        /// Удаление корпоративного аккаунта
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <returns></returns>
        public async Task<Guid> Delete(Guid id)
        {
            await _context.CorporateAccounts
                .Where(ca => ca.AccountId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}