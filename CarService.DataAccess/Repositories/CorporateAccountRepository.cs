using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.DataAccess.Contexts;
using CarService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccess.Repositories
{
    public class CorporateAccountRepository : ICorporateAccountRepository
    {
        private readonly CarServiceDbContext _context;

        public CorporateAccountRepository(CarServiceDbContext context)
        {
            _context = context;
        }

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

        public async Task<Guid> Delete(Guid id)
        {
            await _context.CorporateAccounts
                .Where(ca => ca.AccountId == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}