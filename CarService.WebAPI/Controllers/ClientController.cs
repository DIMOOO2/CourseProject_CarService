using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ClientRequest>> DeleteWarehouse(Guid id)
        {
            return Ok(await _clientService.DeleteClient(id));
        }
    }
}
