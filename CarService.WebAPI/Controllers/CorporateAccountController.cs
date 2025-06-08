using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер корпоративных аккаунтов складов 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CorporateAccountController : ControllerBase
    {
        private readonly ICorporateAccountService _corporateAccountService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="corporateAccountService">Интерфейс сервиса для работы с корпоративными аккаунтами</param>
        public CorporateAccountController(ICorporateAccountService corporateAccountService)
        {
            _corporateAccountService = corporateAccountService;
        }

        /// <summary>
        /// Получение всех корпоративных аккаунтов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение корпоративного аккаунта по ID
        /// </summary>
        /// <param name="id">ID корпоративного аккаунта</param>
        /// <returns></returns>
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

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request">Данные корпоративного аккаунта</param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление корпоративного аккаунта
        /// </summary>
        /// <param name="request">Данные нового корпоративного аккаунта</param>
        /// <returns></returns>
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

        /// <summary>
        /// Обновление корпоративного аккаунта
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <param name="request">Новые данные аккаунта</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAccount(Guid id, [FromBody] CorporateAccountRequest request)
        {
            var warehouseId = await _corporateAccountService.UpdateAccount(id,
                request.logIn,
                request.password,
                request.warehouseId);

            return Ok(warehouseId);
        }

        /// <summary>
        /// Удаление корпоративного аккаунта
        /// </summary>
        /// <param name="id">ID аккаунта</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteWarehouse(Guid id)
        {
            return Ok(await _corporateAccountService.DeleteAccount(id));
        }
    }
}