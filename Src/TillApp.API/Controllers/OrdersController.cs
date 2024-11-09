using Microsoft.AspNetCore.Mvc;
using TillApp.Application.Interfaces;
using TillApp.Domain.Entities;

namespace TillApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            // Calculate the order total from items
            order.Amount = order.Items.Sum(i => i.Price);

            var newOrder = await _orderService.CreateOrderWithItemsAsync(order);
            return Ok(newOrder);
        }

        [HttpGet("unpaid")]
        public async Task<IActionResult> GetUnpaidOrders()
        {
            var unpaidOrders = await _orderService.GetUnpaidOrdersAsync();
            return Ok(unpaidOrders);
        }

        [HttpPut("{orderId}/markAsPaid")]
        public async Task<IActionResult> MarkOrderAsPaid(int orderId)
        {
            await _orderService.MarkOrderAsPaidAsync(orderId);
            return NoContent();
        }
    }
}
