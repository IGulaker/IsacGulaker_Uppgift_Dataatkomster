using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.Address
{
    public interface IAddressManager
    {
        public Task<IActionResult> CreateAddressAsync(CreateAddressModel model);
        public Task<IActionResult> ReadAddressAsync(int id);
        public Task<IEnumerable<RequestAddressModel>> ReadAllAddressesAsync();
        public Task<IActionResult> UpdateAddressAsync(int id, UpdateAddressModel model);
        public Task<IActionResult> DeleteAddressAsync(int id);

        public Task<AddressEntity> GetAddressAsync(int id);
        public Task<AddressEntity> GetAddressAsync(CreateAddressModel model);
    }
}
