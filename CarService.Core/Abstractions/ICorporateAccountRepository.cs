using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface ICorporateAccountRepository
    {
        Task<Guid> Create(CorporateAccount corporateAccount);
        Task<Guid> Delete(Guid id);
        Task<List<CorporateAccount>> Get();
        Task<CorporateAccount> GetWithLoginAndPassword(string login, string password);
        Task<Guid> Update(Guid accountId, string logIn, string password, Guid warehouseId);
    }
}