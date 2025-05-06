using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.newWebAPI.Contracts.Requests;
using CarService.newWebAPI.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorporateAccountController : ControllerBase
    {
        private readonly ICorporateAccountService _corporateAccountService;

        public CorporateAccountController(ICorporateAccountService corporateAccountService)
        {
            _corporateAccountService = corporateAccountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CorporateAccountResponse>>> GetWarehouses()
        {
            var warehouses = await _corporateAccountService.GetAllAccounts();

            var response = warehouses.Select(a => new CorporateAccountResponse(
                a.AccountId,
                a.LogIn,
                a.Password,
                a.WarehouseId));

            return Ok(response);
        }

        [HttpGet("SignIn")]
        public async Task<ActionResult<CorporateAccount>> SignIn(string login, string passwordHash)
        {
            var account = await _corporateAccountService.FindWithProfile(login, passwordHash);

            if(account == null)
            {
                return NotFound(login);
            }

            else
            {
                return Ok(account);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAccount([FromBody] CorporateAccountRequest request)
        {
            var (account, error) = CorporateAccount.Create(
                Guid.NewGuid(),
                request.logIn,
                request.password,
                request.warehouseId);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _corporateAccountService.CreateAccount(account);

            return Ok(account.AccountId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAccount(Guid id, [FromBody] CorporateAccountRequest request)
        {
            var warehouseId = await _corporateAccountService.UpdateAccount(id,
                request.logIn,
                request.password,
                request.warehouseId);

            return Ok(warehouseId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<WarehouseRequest>> DeleteWarehouse(Guid id)
        {
            return Ok(await _corporateAccountService.DeleteAccount(id));
        }
    }
}