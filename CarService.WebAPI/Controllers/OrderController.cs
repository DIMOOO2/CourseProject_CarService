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
                o.ClientId,
                o.WarehouseContractorId
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
                order.ClientId,
                order.WarehouseContractorId
                );

                return Ok(response);
            }

            else return NotFound();
        }

        [HttpGet("fromWarehouse/{warehouesId:guid}")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrdersFromCurrentWarehouse(Guid warehouesId)
        {
            var orderFromWarehouse = await _orderService.GetOrdersFromCurrentWarehouse(warehouesId);

            var response = orderFromWarehouse.Select(o => new OrderResponse
            (
                o.OrderId,
                o.OrderDate,
                o.OrderStatus,
                o.ClientId,
                o.WarehouseContractorId
            ));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<OrderRequest>> CreateOrder([FromBody] OrderRequest request)
        {
            var (order, error) = Order.Create(
                    Guid.NewGuid(),
                    DateTime.Now, 
                    false,
                    request.clientId,
                    request.warehouseContractorId
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _orderService.CreateOrder(order);

            return Ok(order);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> UpdateOrder(Guid id, [FromBody] OrderRequest request)
        {
            var orderId = await _orderService.UpdateOrder(id,
                request.orderDate,
                request.orderStatus,
                request.clientId,
                request.warehouseContractorId);



            return Ok(new OrderResponse(id, request.orderDate, request.orderStatus, request.clientId, request.warehouseContractorId)); 
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteOrder(Guid id)
        {
            return Ok(await _orderService.DeleteOrder(id));
        }
    }
}