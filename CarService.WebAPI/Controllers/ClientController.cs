using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер клиента
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="clientService">Интерфейс сервиса для работы с клиентами</param>
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ClientResponse>>> GetClients()
        {
            var clients = await _clientService.GetAllClients();

            var response = clients.Select(c => new ClientResponse
            (
                c.ClientId, 
                c.FirstName, c.LastName, c.MiddleName, 
                c.PhoneNumber,  
                c.Email, c.Address, c.City ,c.OrganizationId
            ));

            return Ok(response);
        }

        /// <summary>
        /// Получение клиента по ID
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClientResponse>> GetByIdClient(Guid id)
        {
            var client = await _clientService.GetByIdClient(id);

            if (client != null)
            {
                var response = new ClientResponse
                (
                    client.ClientId,
                    client.FirstName, client.LastName, client.MiddleName,
                    client.PhoneNumber,
                    client.Email, client.Address, client.City, client.OrganizationId
                );

                return Ok(response);
            }
            else return NotFound(client);
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="request">Данные нового клиента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ClientResponse>> CreateClient([FromBody] ClientRequest request)
        {
            var (client, error) = Client.Create
                (
                    Guid.NewGuid(),
                    request.firstName,
                    request.lastName,
                    request.middleName,
                    request.phoneNumber,
                    request.email,
                    request.address,
                    request.city,
                    request.organizationId
                );

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            await _clientService.CreateClient(client);

            return Ok(client);
        }

        /// <summary>
        /// Обновление клиента
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <param name="request">Новые данные клиента</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateWarehouse(Guid id, [FromBody] ClientRequest request)
        {
            var clientId = await _clientService.UpdateClient(
                    id,
                    request.firstName,
                    request.lastName,
                    request.middleName,
                    request.phoneNumber,
                    request.email,
                    request.address,
                    request.city,
                    request.organizationId);

            return Ok(clientId);
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id">ID клиента</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClientRequest>> DeleteWarehouse(Guid id)
        {
            return Ok(await _clientService.DeleteClient(id));
        }
    }
}
