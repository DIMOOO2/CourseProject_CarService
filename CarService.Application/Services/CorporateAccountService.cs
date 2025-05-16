using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.ApplicationService.Services
{
    public class CorporateAccountService : ICorporateAccountService
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public CorporateAccountService(ICorporateAccountRepository corporateAccountRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
        }

        public async Task<List<CorporateAccount>> GetAllAccounts()
        {
            return await _corporateAccountRepository.Get();
        }

        public async Task<CorporateAccount> GetByIdAccount(Guid id)
        {
            return await _corporateAccountRepository.GetById(id);
        }

        public async Task<Guid> CreateAccount(CorporateAccount corporateAccount)
        {
            return await _corporateAccountRepository.Create(corporateAccount);
        }

        public async Task<Guid> UpdateAccount(Guid accountId, string logIn, string password, Guid warehouseId)
        {
            return await _corporateAccountRepository.Update(accountId, logIn, password, warehouseId);
        }

        public async Task<Guid> DeleteAccount(Guid id)
        {
            return await _corporateAccountRepository.Delete(id);
        }

        public async Task<CorporateAccount> FindWithProfile(string login, string password)
        {
            return await _corporateAccountRepository.GetWithLoginAndPassword(login, password);
        }
    }
}
