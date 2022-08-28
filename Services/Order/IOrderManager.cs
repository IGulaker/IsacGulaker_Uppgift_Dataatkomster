using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.Order
{
    public interface IOrderManager
    {
        public Task<IActionResult> CreateOrderAsync(CreateOrderModel model);
        public Task<IActionResult> ReadOrderAsync(int id);
        public Task<IEnumerable<RequestOrderModel>> ReadAllOrdersAsync();
        public Task<IActionResult> UpdateOrderAsync(int id, UpdateOrderModel model);
        public Task<IActionResult> DeleteOrderAsync(int id);

        public Task<OrderEntity> GetOrderAsync(int id);
    }
}
