using CarService.Core.Abstractions;
using CarService.Core.Models;

namespace CarService.Application.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public AuthorizeService(ICorporateAccountRepository corporateAccountRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
        }

        public async Task<CorporateAccount> SignIn(string login, string password)
        {
            return await _corporateAccountRepository.GetWithLoginAndPassword(login, password);
        }
    }
}
