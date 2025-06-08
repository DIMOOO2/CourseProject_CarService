using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер организации
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="organizationService">Интерфейс сервиса для работы с организациями</param>
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// Получение всех организаций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<OrganizationResponose>>> GetOrgaanizations()
        {
            var organizations = await _organizationService.GetAllOrganizations();

            var response = organizations.Select(o => new OrganizationResponose(
                o.OrganizationId,
                o.TitleOrganization,
                o.TIN,
                o.Address,
                o.City));

            return Ok(response);
        }

        /// <summary>
        /// Получение организации по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrganizationResponose>> GetOrgaanizationById(Guid id)
        {
            var organization = await _organizationService.GetByIdOrganization(id);

            if(organization != null)
            {
               var response =  new OrganizationResponose(
               organization.OrganizationId,
               organization.TitleOrganization,
               organization.TIN,
               organization.Address,
               organization.City);

               return Ok(response);
            }

            else return NotFound(organization);           
        }
        /// <summary>
        /// Добавление организации
        /// </summary>
        /// <param name="request">Данные новой организации</param>
        /// <returns></returns>
        [HttpPost]  
        public async Task<ActionResult<Guid>> CreateOrganization([FromBody] OrganizationRequest request)
        {
            var (organization, error) = Organization.Create(
                 Guid.NewGuid(),
                 request.titleOrganization,
                 request.tIN,
                 request.address,
                 request.city);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _organizationService.CreateOrganization(organization);

            return Ok(new OrganizationResponose(organization.OrganizationId, organization.TitleOrganization, organization.TIN, organization.Address, organization.City));
        }

        /// <summary>
        /// Обнолвение организации
        /// </summary>
        /// <param name="id">ID организации</param>
        /// <param name="request">Новые данные организации</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrganization(Guid id, [FromBody] OrganizationRequest request)
        {
            var organizationId = await _organizationService.UpdateOrganization(
                id,
                request.titleOrganization,
                request.tIN,
                request.address,
                request.city);

            return Ok(organizationId);
        }

        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="id">ID организации</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrganizationRequest>> DeleteOrganization(Guid id)
        {
            return Ok(await _organizationService.DeleteOrganization(id));
        }
    }
}
