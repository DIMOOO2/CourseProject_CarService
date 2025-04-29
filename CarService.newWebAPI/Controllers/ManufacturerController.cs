using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.newWebAPI.Contracts.Requests;
using CarService.newWebAPI.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ManufacturerResponse>>> GatManufacturers()
        {
            var manufacturers = await _manufacturerService.GetAllManufacturers();

            var response = manufacturers.Select(m => new ManufacturerResponse(
                m.ManufacturerId,
                m.ManufacturerName,
                m.ContactInfo));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateManufacturer([FromBody] ManufacturerRequest request)
        {
            var (manufacturer, error) = Manufacturer.Create
                (
                    Guid.NewGuid(),
                    request.manufacturerName,
                    request.contactInfo
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _manufacturerService.CreateManufacturer(manufacturer);

            return Ok(manufacturer.ManufacturerId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateManufacturer(Guid id, [FromBody] ManufacturerRequest request)
        {
            var manufacturerId = await _manufacturerService.UpdateManufacturer(id,
                request.manufacturerName,
                request.contactInfo);

            return Ok(manufacturerId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ManufacturerRequest>> DeleteWarehouse(Guid id)
        {
            return Ok(await _manufacturerService.DeleteManufacturer(id));
        }
    }
}
