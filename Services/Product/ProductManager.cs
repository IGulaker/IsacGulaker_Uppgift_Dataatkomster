using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsacGulaker_Uppgift_Dataatkomster.Services.Product
{
    public class ProductManager : IProductManager
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductManager(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> CreateProductAsync(CreateProductModel model)
        {
            ProductEntity productEntity = await GetProductAsync(model);
            if (productEntity == null)
            {
                productEntity = _mapper.Map<ProductEntity>(model);

                await _context.Products.AddAsync(productEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult("A product has been created");
            }

            return new ConflictObjectResult("Product already exists");
        }

        public async Task<IActionResult> ReadProductAsync(int id)
        {
            ProductEntity productEntity = await GetProductAsync(id);
            if (productEntity != null)
            {
                RequestProductModel requestProductModel = _mapper.Map<RequestProductModel>(productEntity);

                return new OkObjectResult(requestProductModel);
            }

            return new BadRequestObjectResult("Could not find product by given id");
        }

        public async Task<IEnumerable<RequestProductModel>> ReadAllProductsAsync()
        {
            List<ProductEntity> productEntities = await _context.Products.ToListAsync();
            List<RequestProductModel> requestProductModels = new();

            for (int i = 0; i < productEntities.Count; i++)
                requestProductModels.Add(_mapper.Map<RequestProductModel>(productEntities[i]));

            return requestProductModels;
        }

        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductModel model)
        {
            ProductEntity productEntity = await GetProductAsync(id);
            if (productEntity != null)
            {
                productEntity.Name = model.NewProductName;
                productEntity.Description = model.NewProductDescription;
                productEntity.Price = model.NewProductPrice;
                productEntity.LastModified = DateTime.Now;

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new OkObjectResult("Product has been modified");
            }

            return new BadRequestObjectResult("Could not find product by given id");
        }

        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            ProductEntity productEntity = await GetProductAsync(id);
            string productName;
            if (productEntity != null)
            {
                productName = productEntity.Name;

                _context.Products.Remove(productEntity);

                await _context.SaveChangesAsync();

                return new OkObjectResult($"Address on {productName} has been removed from the database");
            }

            return new BadRequestObjectResult("Could not find an address to remove by given id");
        }

        public async Task<ProductEntity> GetProductAsync(int id)
        {
            return await _context.Products.Include(x => x.Manufacturer).Include(x => x.Subcategory).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductEntity> GetProductAsync(CreateProductModel model)
        {
            return await _context.Products.Include(x => x.Manufacturer).Include(x => x.Subcategory).ThenInclude(x => x.Category).FirstOrDefaultAsync(x =>
            (x.Name == model.NewProductName && x.Description == model.NewProductDescription && x.Price == model.NewProductPrice) || x.EAN_13 == model.NewProductEAN_13);
        }
    }
}
