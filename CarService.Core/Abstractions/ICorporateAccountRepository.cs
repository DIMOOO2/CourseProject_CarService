using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface ICorporateAccountRepository
    {
        Task<Guid> Create(CorporateAccount corporateAccount);
        Task<Guid> Delete(Guid id);
        Task<List<CorporateAccount>> Get();
        Task<Guid> Update(Guid accountId, string logIn, string password, Guid warehouseId);
    }
}