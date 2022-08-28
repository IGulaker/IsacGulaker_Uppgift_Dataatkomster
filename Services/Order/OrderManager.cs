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
        private readonly IMapper mapper;

        public OrderManager(DataContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public Task<IActionResult> CreateOrderAsync(CreateOrderModel model)
        {
            OrderEntity orderEntity = await GetAddressAsync(model);
            if (orderEntity == null)
            {
                orderEntity = _mapper.Map<AddressEntity>(model);

                await _context.Addresses.AddAsync(orderEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult("An address has been created");
            }

            return new ConflictObjectResult("Address already exists");
        }

        public Task<IActionResult> ReadOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestOrderModel>> ReadAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> GetOrderAsync(CreateOrderModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateOrderAsync(int id, UpdateOrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
