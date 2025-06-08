using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер склада
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="warehouseService">Интерфейс сервиса для работы со складами</param>
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        /// <summary>
        /// Получение всех складов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение склада по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление склада
        /// </summary>
        /// <param name="request">Данные нового склада</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<WarehouseResponse>> CreateWarehouse([FromBody] WarehouseRequest request)
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

            return Ok(new WarehouseResponse(warehouse.WarehouseId, warehouse.Title, warehouse.Address, warehouse.City));
        }

        /// <summary>
        /// Обвноление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <param name="request">Новые данные склада</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateWarehouse(Guid id, [FromBody] WarehouseRequest request)
        {
            var warehouseId = await _warehouseService.UpdateWarehouse(id,
                request.Title,
                request.Address,
                request.City);

            return Ok(warehouseId);
        }

        /// <summary>
        /// Удаление склада
        /// </summary>
        /// <param name="id">ID склада</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteWarehouse(Guid id)
        {
            return Ok(await _warehouseService.DeleteWarehouse(id));
        }
    }
}