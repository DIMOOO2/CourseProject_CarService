using CarService.Application.Services;
using CarService.Core.Abstractions;
using CarService.newWebAPI.Contracts.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AutorizationController : Controller
    {
        private readonly ICorporateAccountService _corporateAccountService;

        public AutorizationController(ICorporateAccountService corporateAccountService)
        {
            _corporateAccountService = corporateAccountService;
        }

        [HttpPost]
        public async Task<ActionResult<CorporateAccountResponse>> LogIn(string login, string password)
        {
            return Ok(await _corporateAccountService.FindWithProfile(login, password));
        }
    }
}
