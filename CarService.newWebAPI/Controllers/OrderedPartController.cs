using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderedPartController : ControllerBase
    {
        private readonly IOrderedPartService _orderedPartService;

        public OrderedPartController(IOrderedPartService orderedPartService)
        {
            _orderedPartService = orderedPartService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderedPartResponse>>> GetOrderedParts()
        {
            var orderedParts = await _orderedPartService.GetAllOrderedParts();

            var response = orderedParts.Select(op => new OrderedPartResponse(
                op.OrderedPartId,
                op.Amount,
                op.OrderId,
                op.AutoPartId,
                op.DepartureWarehouseId,
                op.ArrivalWarehouseId));

            return Ok(response);
        }

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
                orderedPart.DepartureWarehouseId,
                orderedPart.ArrivalWarehouseId);

                return Ok(response);
            }

            else return NotFound(orderedPart);
        }

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
                    item.departureWarehouseId,
                    item.arrivalWarehouseId
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

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrderedPart(Guid id, [FromBody] OrderedPartRequest request)
        {
            var orderedPartId = await _orderedPartService.UpdateOrderedParts
                (
                    id, request.amount, request.orderId, request.autoPartId,
                    request.departureWarehouseId, request.arrivalWarehouseId
                );

            return Ok(orderedPartId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrderedPartRequest>> DeleteOrderedPart(Guid id)
        {
            return Ok(await _orderedPartService.DeleteOrderedPart(id));
        }
    }
}