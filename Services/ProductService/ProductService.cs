using Examination_WebApi.Data;
using Examination_WebApi.Models.Entities;
using Examination_WebApi.Models.Products;
using Examination_WebApi.Services.CartService;
using Examination_WebApi.Services.CategoryService;
using Examination_WebApi.Services.InventoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService _categoryService;
        private readonly IInventoryService _inventoryService;
        private readonly ICartService _cartService;
        private readonly DataContext _context;

        public ProductService(ICategoryService categoryService, IInventoryService inventoryService, ICartService cartService, DataContext context)
        {
            _categoryService = categoryService;
            _inventoryService = inventoryService;
            _cartService = cartService;
            _context = context;
        }

        public async Task<ActionResult<ReadProductModel>> CreateProductAsync(CreateProductModel model)
        {
            ProductEntity product = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = (await _categoryService.FindOrCreateCategoryAsync(model.CategoryName)).Id,
                InventoryId = (await _inventoryService.CreateProductInventoryAsync(model.Quantity)).Id
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return new ObjectResult(new ReadProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Name,
                Quantity = product.Inventory.Quantity
                
            });
        }

        public async Task<ActionResult<IEnumerable<ReadProductModel>>> ReadProductsAsync()
        {
            List<ReadProductModel> result = new();

            foreach (ProductEntity product in await _context.Products.Include(x => x.Category)
                .Include(x => x.Inventory).ToListAsync())
            {
                result.Add(new ReadProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category.Name,
                    Quantity = product.Inventory.Quantity
                    
                });
            }

            return new ObjectResult(result);
        }

        public async Task<ActionResult<ReadProductModel>> ReadProductAsync(int id)
        {
            ProductEntity? product = await _context.Products
                .Include(x => x.Category).Include(x => x.Inventory)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return new BadRequestResult();
            }

            return new ObjectResult(new ReadProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Name,
                Quantity = product.Inventory.Quantity
            });
        }

        public async Task<ActionResult> UpdateProductAsync(int id, UpdateProductModel model)
        {
            ProductEntity? product = await _context.Products
                .Include(x => x.Category).Include(x => x.Inventory)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return new BadRequestResult();
            }

            string categoryName = product.Category.Name;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = (await _categoryService.FindOrCreateCategoryAsync(model.CategoryName)).Id;
            product.Inventory.Quantity = model.Quantity;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await _categoryService.RemoveEmptyCategoriesAsync(categoryName);

            return new NoContentResult();
        }


        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            ProductEntity? product = await _context.Products
                .Include(x => x.Category).Include(x => x.Inventory)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return new BadRequestResult();
            }

            await _cartService.DeleteAllCartItemsWithDeletedProduct(product.Id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            await _inventoryService.DeleteProductInventoryAsync(product.InventoryId);
            await _categoryService.RemoveEmptyCategoriesAsync(product.Category.Name);

            return new NoContentResult();
        }
    }
}
