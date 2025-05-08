using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.newWebAPI.Contracts.Requests;
using CarService.newWebAPI.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoPartController : ControllerBase
    {
        private IAutoPartService _autoPartService;

        public AutoPartController(IAutoPartService autoPartService)
        {
            _autoPartService = autoPartService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutoPartResponse>>> GetAutoParts()
        {
            var autoparts = await _autoPartService.GetAllAutoParts();

            var response = autoparts.Select(a => new AutoPartResponse
            (
                a.AutoPartId,
                a.AutoPartName,
                a.PartNumber,
                a.Price,
                a.StockAmount,
                a.ManufacturerId,
                a.WarehouseId
            ));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<AutoPartResponse>>> GetAutoPartById(Guid id)
        {
            var autopart = await _autoPartService.GetByIdAutoPart(id);

            if (autopart != null)
            {
                var response = new AutoPartResponse
                (
                    autopart.AutoPartId,
                    autopart.AutoPartName,
                    autopart.PartNumber,
                    autopart.Price,
                    autopart.StockAmount,
                    autopart.ManufacturerId,
                    autopart.WarehouseId
                );

                return Ok(response);
            }
            else return NotFound(autopart);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAutoPart([FromBody] AutoPartRequest request)
        {
            var (autopart, error) = AutoPart.Create(
                Guid.NewGuid(),
                request.autoPartName,
                request.partNumber,
                request.price,
                request.stockAmount,
                request.manufacturerId,
                request.warehouseId);

            if (!string.IsNullOrEmpty(error))
                return BadRequest(error);

            await _autoPartService.CreateAutopart(autopart);

            return Ok(autopart.AutoPartId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAutoPart(Guid id, [FromBody] AutoPartRequest request)
        {
            var autopartId = await _autoPartService.UpdateAutoPart(id,
                request.autoPartName,
                request.partNumber,
                request.price,
                request.stockAmount,
                request.manufacturerId,
                request.warehouseId);

            return Ok(autopartId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AutoPartRequest>> DeleteAutoPart(Guid id)
        {
            return Ok(await _autoPartService.DeleteAutoPart(id));
        }
    }
}
