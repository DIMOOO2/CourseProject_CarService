using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

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

            return Ok(organization.OrganizationId);
        }

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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrganizationRequest>> DeleteOrganization(Guid id)
        {
            return Ok(await _organizationService.DeleteOrganization(id));
        }
    }
}
