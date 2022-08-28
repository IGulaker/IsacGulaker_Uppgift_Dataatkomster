using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.Address
{
    public class AddressManager : IAddressManager
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AddressManager(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateAddressAsync(CreateAddressModel model)
        {
            AddressEntity addressEntity = await GetAddressAsync(model);
            if (addressEntity == null)
            {
                addressEntity = _mapper.Map<AddressEntity>(model);

                await _context.Addresses.AddAsync(addressEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult("An address has been created");
            }

            return new ConflictObjectResult("Address already exists");
        }

        public async Task<IActionResult> ReadAddressAsync(int id)
        {
            AddressEntity addressEntity = await GetAddressAsync(id);
            if (addressEntity != null)
            {
                RequestAddressModel requestAddressModel = _mapper.Map<RequestAddressModel>(addressEntity);

                return new OkObjectResult(requestAddressModel);
            }

            return new BadRequestObjectResult("Could not find address by given id");
        }

        public async Task<IEnumerable<RequestAddressModel>> ReadAllAddressesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> UpdateAddressAsync(int id, UpdateAddressModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressEntity> GetAddressAsync(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }        

        public async Task<AddressEntity> GetAddressAsync(CreateAddressModel model)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.City == model.NewAddressCity && 
                                                                     x.PostalCode == model.NewAddressPostalCode && 
                                                                     x.StreetName == model.NewAddressStreetName && 
                                                                     x.ResidenceNumber == model.NewAddressResidenceNumber);
        }
    }
}
