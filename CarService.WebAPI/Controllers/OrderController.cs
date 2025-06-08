using CarService.Core.Abstractions;
using CarService.Core.Models;
using CarService.ApplicationService.Contracts.Requests;
using CarService.ApplicationService.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace CarService.newWebAPI.Controllers
{
    /// <summary>
    /// Контроллер заказа
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderService">Интерфейс сервиса для работы с заказами</param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение заказа по ID
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение всех заказов на конкретном складе
        /// </summary>
        /// <param name="warehouesId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление заказа
        /// </summary>
        /// <param name="request">Данные нового заказа</param>
        /// <returns></returns>
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

        /// <summary>
        /// Обновление заказа
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <param name="request">Новые данные заказа</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id">ID заказа</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteOrder(Guid id)
        {
            return Ok(await _orderService.DeleteOrder(id));
        }
    }
}