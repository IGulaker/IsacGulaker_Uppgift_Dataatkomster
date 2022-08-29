using IsacGulaker_Uppgift_Dataatkomster.Filters;
using IsacGulaker_Uppgift_Dataatkomster.Models.Product;
using IsacGulaker_Uppgift_Dataatkomster.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        [UseAdminApiKey]
        [Authorize]
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
        [UseAdminApiKey]
        public async Task<IActionResult> PutProductAsync(int id, UpdateProductModel model)
        {
            return await _productManager.UpdateProductAsync(id, model);
        }

        [HttpDelete("{id:int}")]
        [UseAdminApiKey]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            return await _productManager.DeleteProductAsync(id);
        }
    }
}
