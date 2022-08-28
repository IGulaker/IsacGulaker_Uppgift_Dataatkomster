using IsacGulaker_Uppgift_Dataatkomster.Models.Order;
using IsacGulaker_Uppgift_Dataatkomster.Services.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync(CreateOrderModel model)
        {
            return await _orderManager.CreateOrderAsync(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            return await _orderManager.ReadOrderAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return new OkObjectResult(await _orderManager.ReadAllOrdersAsync());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutOrderAsync(int id, UpdateOrderModel model)
        {
            return await _orderManager.UpdateOrderAsync(id, model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            return await _orderManager.DeleteOrderAsync(id);
        }
    }
}
