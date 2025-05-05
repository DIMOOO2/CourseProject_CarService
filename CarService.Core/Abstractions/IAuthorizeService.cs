using CarService.Core.Models;

namespace CarService.Core.Abstractions
{
    public interface IAuthorizeService
    {
        Task<CorporateAccount> SignIn(string login, string password);
    }
}