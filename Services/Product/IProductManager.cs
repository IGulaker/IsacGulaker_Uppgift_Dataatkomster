using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.Product
{
    public interface IProductManager
    {
        public Task<IActionResult> CreateProductAsync(CreateProductModel model);
        public Task<IActionResult> ReadProductAsync(int id);
        public Task<IEnumerable<RequestProductModel>> ReadAllProductsAsync();
        public Task<IActionResult> UpdateProductAsync(int id, UpdateProductModel model);
        public Task<IActionResult> DeleteProductAsync(int id);

        public Task<ProductEntity> GetProductAsync(int id);
        public Task<ProductEntity> GetProductAsync(CreateProductModel model);
    }
}
