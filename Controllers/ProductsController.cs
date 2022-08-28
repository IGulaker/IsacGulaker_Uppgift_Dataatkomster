using IsacGulaker_Uppgift_Dataatkomster.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostProductAsync(CreateProductModel model)
        {
            return await _productManager.CreateProductAsync(model);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            return await _productManager.ReadProductAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            return new OkObjectResult(await _productManager.ReadAllProductsAsync());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAddressAsync(int id, UpdateProductModel model)
        {
            return await _productManager.UpdateProductAsync(id, model);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            return await _productManager.DeleteProductAsync(id);
        }
    }
}
