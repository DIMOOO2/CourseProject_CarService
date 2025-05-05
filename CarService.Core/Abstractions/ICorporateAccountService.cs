using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface ICorporateAccountService
    {
        Task<Guid> CreateAccount(CorporateAccount corporateAccount);
        Task<Guid> DeleteAccount(Guid id);
        Task<CorporateAccount> FindWithProfile(string login, string password);
        Task<List<CorporateAccount>> GetAllAccounts();
        Task<Guid> UpdateAccount(Guid accountId, string logIn, string password, Guid warehouseId);
    }
}