using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            OrderEntity orderEntity = await GetOrderAsync(id);
            if (orderEntity != null)
            {
                RequestOrderModel requestOrderModel = _mapper.Map<RequestOrderModel>(orderEntity);

                return new OkObjectResult(requestOrderModel);
            }

            return new BadRequestObjectResult("Could not find order by given id");
        }

        public async Task<IEnumerable<RequestOrderModel>> ReadAllOrdersAsync()
        {
            List<OrderEntity> orderEntities = await _context.Orders.ToListAsync();
            List<RequestOrderModel> requestOrderModels = new();

            for (int i = 0; i < orderEntities.Count; i++)
                requestOrderModels.Add(_mapper.Map<RequestOrderModel>(orderEntities[i]));

            return requestOrderModels;
        }

        public async Task<IActionResult> UpdateOrderAsync(int id, UpdateOrderModel model)
        {
            OrderEntity orderEntity = await GetOrderAsync(id);
            if (orderEntity != null)
            {
                orderEntity.ProductQuantity = model.ProductQuantity;
                orderEntity.City = model.City;
                orderEntity.PostalCode = model.PostalCode;
                orderEntity.StreetName = model.StreetName;
                orderEntity.ResidenceNumber = model.ResidenceNumber;

                _context.Entry(orderEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new OkObjectResult("Order has been modified");
            }

            return new BadRequestObjectResult("Could not find order by given id");
        }

        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            OrderEntity orderEntity = await GetOrderAsync(id);
            string OrderName;
            if (orderEntity != null)
            {
                OrderName = orderEntity.Id + " on article " + orderEntity.ProductEAN_13;

                _context.Orders.Remove(orderEntity);

                await _context.SaveChangesAsync();

                return new OkObjectResult($"Ordernumber {OrderName} has been removed from the database");
            }

            return new BadRequestObjectResult("Could not find an order to remove by given id");
        }

        public async Task<OrderEntity> GetOrderAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
