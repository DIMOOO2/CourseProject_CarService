using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.newWebAPI.Contracts.Requests;
using CarService.newWebAPI.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CarService.newWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrders();

            var response = orders.Select(o => new OrderResponse(
                o.OrderId,
                o.OrderDate,
                o.OrderStatus,
                o.ClientId
                ));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrderById(Guid id)
        {
            var order = await _orderService.GetByIdOrder(id);

            if (order != null)
            {
                var response = new OrderResponse(
                order.OrderId,
                order.OrderDate,
                order.OrderStatus,
                order.ClientId
                );

                return Ok(response);
            }

            else return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder([FromBody] OrderRequest request)
        {
            var (order, error) = Order.Create(
                    Guid.NewGuid(),
                    DateTime.Now, 
                    false,
                    request.clientId
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _orderService.CreateOrder(order);

            return Ok(order.OrderId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateOrder(Guid id, [FromBody] OrderRequest request)
        {
            var orderId = await _orderService.UpdateOrder(id,
                request.orderDate,
                request.orderStatus,
                request.clientId);

            return Ok(orderId); 
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<OrderRequest>> DeleteOrder(Guid id)
        {
            return Ok(await _orderService.DeleteOrder(id));
        }
    }
}