using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WarehouseResponse>>> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehouse();

            var response = warehouses.Select(w => new WarehouseResponse(
                w.WarehouseId,
                w.Title,
                w.Address,
                w.City));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<WarehouseResponse>>> GetWarehouseById(Guid id)
        {
            var warehouse = await _warehouseService.GetByIdWarehouse(id);

            if (warehouse != null)
            {
                var response = new WarehouseResponse(
                warehouse.WarehouseId,
                warehouse.Title,
                warehouse.Address,
                warehouse.City);

                return Ok(response);
            }

            else return NotFound(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWarehouse([FromBody] WarehouseRequest request)
        {
            var (warehouse, error) = Warehouse.Create(
                Guid.NewGuid(),
                request.Title,
                request.Address,
                request.City);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _warehouseService.CreateWarehouse(warehouse);

            return Ok(warehouse.WarehouseId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateWarehouse(Guid id, [FromBody] WarehouseRequest request)
        {
            var warehouseId = await _warehouseService.UpdateWarehouse(id,
                request.Title,
                request.Address,
                request.City);

            return Ok(warehouseId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<WarehouseRequest>> DeleteWarehouse(Guid id)
        {
            return Ok(await _warehouseService.DeleteWarehouse(id));
        }
    }
}