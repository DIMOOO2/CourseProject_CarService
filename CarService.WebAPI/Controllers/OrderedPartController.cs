using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер запчасти в заказе
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderedPartController : ControllerBase
    {
        private readonly IOrderedPartService _orderedPartService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderedPartService">Интерфейс сервиса для работы с запчастями в заказах</param>
        public OrderedPartController(IOrderedPartService orderedPartService)
        {
            _orderedPartService = orderedPartService;
        }

        /// <summary>
        /// Получение всех автозапчастей в заказах
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<OrderedPartResponse>>> GetOrderedParts()
        {
            var orderedParts = await _orderedPartService.GetAllOrderedParts();

            var response = orderedParts.Select(op => new OrderedPartResponse(
                op.OrderedPartId,
                op.Amount,
                op.OrderId,
                op.AutoPartId,
                op.DepartureWarehouseId));

            return Ok(response);
        }

        /// <summary>
        /// Получение запчасти в заказе по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<OrderedPartResponse>>> GetOrderedPartById(Guid id)
        {
            var orderedPart = await _orderedPartService.GetByIdOrderedPart(id);

            if (orderedPart != null)
            {
                var response = new OrderedPartResponse(
                orderedPart.OrderedPartId,
                orderedPart.Amount,
                orderedPart.OrderId,
                orderedPart.AutoPartId,
                orderedPart.DepartureWarehouseId);

                return Ok(response);
            }

            else return NotFound(orderedPart);
        }

        /// <summary>
        /// Добавление запчасти в заказе
        /// </summary>
        /// <param name="request">Данные запчасти</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<OrderedPartResponse>>> CreateOrderedPart([FromBody] List<OrderedPartRequest> request)
        {
            List<OrderedPart> orderedParts = new List<OrderedPart>();
            foreach (var item in request)
            {
                var (orderedPart, error) = OrderedPart.Create
                (
                    Guid.NewGuid(),
                    item.amount,
                    item.orderId,
                    item.autoPartId,
                    item.departureWarehouseId
                );

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }
                else orderedParts.Add(orderedPart);

            }

            await _orderedPartService.CreateOrderedParts(orderedParts);

            return Ok(orderedParts);
        }

        /// <summary>
        /// Обновление запчасти в заказе
        /// </summary>
        /// <param name="id">ID запчасти</param>
        /// <param name="request">Новые данные запчасти</param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrderedPart(Guid id, [FromBody] OrderedPartRequest request)
        {
            var orderedPartId = await _orderedPartService.UpdateOrderedParts
                (
                    id, request.amount, request.orderId, request.autoPartId,
                    request.departureWarehouseId
                );

            return Ok(orderedPartId);
        }

        /// <summary>
        /// Удаление запчасти в заказе
        /// </summary>
        /// <param name="id">ID запчасти</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrderedPartRequest>> DeleteOrderedPart(Guid id)
        {
            return Ok(await _orderedPartService.DeleteOrderedPart(id));
        }
    }
}