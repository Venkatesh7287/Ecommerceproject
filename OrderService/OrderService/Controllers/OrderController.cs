using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Model;
using OrderService.Service;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var order = await _orderService.GetAllOrderAsync();
            return Ok(order);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomerIdAsync(string customerId)
        {
            var order = await _orderService.GetOrderByCustomerIdAsync(customerId);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await _orderService.PlaceOrderAsync(order);
            return Ok(new {message = "Order Created Successfully"});
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string status)
        {
            await _orderService.UpdateOrderAsync(id, status);
            return Ok(new { message = "Order Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.CancelOrderAsync(id);
            return Ok(new { message = "Order Cancelled Successfully" });
        }
    }
}
