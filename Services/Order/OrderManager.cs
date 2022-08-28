using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderManager(DataContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<IActionResult> CreateOrderAsync(CreateOrderModel model)
        {
                OrderEntity orderEntity = _mapper.Map<OrderEntity>(model);

                await _context.Orders.AddAsync(orderEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult("An order has been created");
        }

        public async Task<IActionResult> ReadOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RequestOrderModel>> ReadAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderEntity> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> UpdateOrderAsync(int id, UpdateOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
