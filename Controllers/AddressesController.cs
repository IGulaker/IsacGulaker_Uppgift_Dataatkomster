using IsacGulaker_Uppgift_Dataatkomster.Filters;
using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using IsacGulaker_Uppgift_Dataatkomster.Services.Address;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressManager _addressManager;

        public AddressesController(IAddressManager addressManager)
        {
            _addressManager = addressManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostAddressAsync(CreateAddressModel model)
        {
            return await _addressManager.CreateAddressAsync(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAddressAsync(int id)
        {
            return await _addressManager.ReadAddressAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressesAsync()
        {
            return new OkObjectResult(await _addressManager.ReadAllAddressesAsync());
        }

        [HttpPut("{id:int}")]
        [UseAdminApiKey]
        public async Task<IActionResult> PutAddressAsync(int id, UpdateAddressModel model)
        {
            return await _addressManager.UpdateAddressAsync(id, model);
        }

        [HttpDelete("{id:int}")]
        [UseAdminApiKey]
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            return await _addressManager.DeleteAddressAsync(id);
        }
    }
}
