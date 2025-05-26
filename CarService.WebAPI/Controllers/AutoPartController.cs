using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

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
        public async Task<ActionResult<AutoPartResponse>> GetAutoPartById(Guid id)
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

        [HttpGet("fromWarehouse/{warehouesId:guid}")]
        public async Task<ActionResult<ObservableCollection<AutoPartResponse>>> GetAutoPartFromCurrentWarehouse(Guid warehouesId)
        {
            var autopartsFromWarehouse = await _autoPartService.GetAutoPartsFromCurrentWarehouse(warehouesId);

            var response = autopartsFromWarehouse.Select(a => new AutoPartResponse
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

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAutoPart([FromBody] AutoPartRequest request)
        {
            Guid guid = Guid.NewGuid();
            byte[] data = guid.ToByteArray();
            

            var (autopart, error) = AutoPart.Create(
                guid,
                request.autoPartName,
                Convert.ToInt64(Math.Abs(BitConverter.ToInt32(data, 0))),
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