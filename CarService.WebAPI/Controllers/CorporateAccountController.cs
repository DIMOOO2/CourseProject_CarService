using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
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
        public async Task<ActionResult<List<CorporateAccountResponse>>> GetAccounts()
        {
            var warehouses = await _corporateAccountService.GetAllAccounts();

            var response = warehouses.Select(a => new CorporateAccountResponse(
                a.AccountId,
                a.LogIn,
                a.Password,
                a.WarehouseId));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<CorporateAccountResponse>>> GetAccountById(Guid id)
        {
            var account = await _corporateAccountService.GetByIdAccount(id);

            if (account != null)
            {
                var response = new CorporateAccountResponse(
                account.AccountId,
                account.LogIn,
                account.Password,
                account.WarehouseId);

                return Ok(response);
            }
            else return NotFound(account);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<CorporateAccount>> SignIn([FromBody] CorporateAccountRequest request)
        {
            var account = await _corporateAccountService.FindWithProfile(request.logIn, request.password);

            if(account == null)
            {
                return NotFound(request);
            }

            else
            {
                return Ok(new CorporateAccountResponse(account.AccountId, account.LogIn, account.Password, account.WarehouseId));
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
        public async Task<ActionResult<Guid>> DeleteWarehouse(Guid id)
        {
            return Ok(await _corporateAccountService.DeleteAccount(id));
        }
    }
}